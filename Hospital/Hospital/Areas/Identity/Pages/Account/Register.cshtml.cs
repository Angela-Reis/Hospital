// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Hospital.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UtilizadorApp> _signInManager;
        private readonly UserManager<UtilizadorApp> _userManager;
        private readonly IUserStore<UtilizadorApp> _userStore;
        private readonly IUserEmailStore<UtilizadorApp> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RegisterModel(
            UserManager<UtilizadorApp> userManager,
            IUserStore<UtilizadorApp> userStore,
            SignInManager<UtilizadorApp> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// Obter dados do Utente
            /// </summary>
            public Utentes Utente { get; set; }

            [DataType(DataType.Upload)]
            public IFormFile NovaFoto { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            //se a foto não existe atribuir a foto 'semFoto.png' ao utente
            if (Input.NovaFoto == null)
            {
                Input.Utente.Foto = "semFoto.png";
            }
            else //se uma novo foto tiver sido selecionada pelo utilizador
            {
                if (!(Input.NovaFoto.ContentType == "image/jpeg" || Input.NovaFoto.ContentType == "image/png"))
                {
                    // Mostra um erro
                    ModelState.AddModelError("", "Foto enviada não é uma imagem");
                    // Devolve controlo a view, com os dados previamente inseridos
                    return Page();
                }
                else
                {
                    // define image name
                    Guid g = Guid.NewGuid();
                    string nomeImg = Input.Utente.NumUtente + "_GUID" + g.ToString();
                    string tipoImagem = Path.GetExtension(Input.NovaFoto.FileName).ToLower();
                    nomeImg += tipoImagem;
                    // add image name to vet data
                    Input.Utente.Foto = nomeImg;
                }
            }

            //ignorar a validação do componente Input.Utente.Email, visto que este será copiado de Input.Email
            ModelState["Input.Utente.Email"].Errors.Clear();
            ModelState["Input.Utente.Email"].ValidationState = ModelValidationState.Valid;

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                //adicionar Nome e Data de Registro ao Utilizador
                user.Nome = Input.Utente.Nome;
                user.DataRegistro = DateTime.Now;

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // associar o utilizador criado desta forma ao "Role" de "Utente"
                    await _userManager.AddToRoleAsync(user, "Utente");

                    //adicionar FK ao utente
                    Input.Utente.IdUtilizador = user.Id;
                    // Guardar o utente adicionando os dados que faltam
                    Input.Utente.Email = Input.Email;

                    try
                    {
                        _context.Add(Input.Utente);
                        await _context.SaveChangesAsync();


                        // guarda o ficheiro da imagem no disco
                        if (Input.NovaFoto != null)
                        {
                            // pergunta ao servidor o endereço a usar
                            string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                            string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Utentes");
                            // verifica se a diretoria existe, se não existir criar
                            if (!Directory.Exists(novaLocalFicheiro))
                            {
                                Directory.CreateDirectory(novaLocalFicheiro);
                            }
                            // guarda imagem no disco
                            novaLocalFicheiro = Path.Combine(novaLocalFicheiro, Input.Utente.Foto);
                            using var stream = new FileStream(novaLocalFicheiro, FileMode.Create);
                            await Input.NovaFoto.CopyToAsync(stream);
                        }

                    }
                    catch (Exception)
                    {
                        // se chegei aqui, aconteceu um problema
                        // o que fazer????
                        //
                        // É necessario fazer um Rollback ao processo
                        // o que significa - eliminar o utilizador previamente criado
                        await _userManager.DeleteAsync(user);
                        // Enviar erro ao utilizador
                        ModelState.AddModelError("", "Ocorreu um erro com a criação do Utilizador");
                        // devolver o controlo ao utilizador
                        return Page();
                    }



                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private UtilizadorApp CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UtilizadorApp>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UtilizadorApp)}'. " +
                    $"Ensure that '{nameof(UtilizadorApp)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<UtilizadorApp> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<UtilizadorApp>)_userStore;
        }
    }
}
