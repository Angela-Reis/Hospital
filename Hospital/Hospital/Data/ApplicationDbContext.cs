using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hospital.Data
{
    /// <summary>
    /// Classe que representa os novos dados do Utilizador
    /// </summary>
    public class UtilizadorApp : IdentityUser
    {
        /// <summary>
        ///  Nome do Utilizador
        /// </summary>
        [Required]
        [StringLength(128, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Data de Registro
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataRegistro { get; set; }


    }

    public class ApplicationDbContext : IdentityDbContext<UtilizadorApp>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // importa a execução previa do método
            base.OnModelCreating(modelBuilder);

            // criar os perfis de utilizador da app
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "a", Name = "Administrativo", NormalizedName = "ADMINISTRATIVO" },
               new IdentityRole { Id = "m", Name = "Medico", NormalizedName = "MEDICO" },
               new IdentityRole { Id = "u", Name = "Utente", NormalizedName = "UTENTE" }
            );

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            //Seed Contas Admin
            modelBuilder.Entity<UtilizadorApp>().HasData(
                new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Admin",
                    Id = "a370779b-8777-4d3b-a96c-7a94d217e355",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    NormalizedUserName = "admin@admin.com".ToUpper(),
                    NormalizedEmail = "admin@admin.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Admin1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                },
                new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Admin2",
                    Id = "93b9ebd2-3f4d-4009-8d8b-3a3404f85628",
                    UserName = "admin2@admin.com",
                    Email = "admin2@admin.com",
                    NormalizedUserName = "admin2@admin.com".ToUpper(),
                    NormalizedEmail = "admin2@admin.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Admin2!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }
            );


            //seed contas médicos
            modelBuilder.Entity<UtilizadorApp>().HasData(
                new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Natália Cardoso",
                    Email = "cardoso@email.com",
                    UserName = "cardoso@email.com",
                    NormalizedEmail = "cardoso@email.com".ToUpper(),
                    NormalizedUserName = "cardoso@email.com".ToUpper(),
                    Id = "388c89b7-046e-414a-8212-1cced6e1aea1",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Luiz Fernando da Paz",
                    Email = "Luizpaz59181@email.com",
                    UserName = "Luizpaz59181@email.com",
                    NormalizedEmail = "Luizpaz59181@email.com".ToUpper(),
                    NormalizedUserName = "Luizpaz59181@email.com".ToUpper(),
                    Id = "b092ad4f-06b8-427f-bc38-cab75e79fc7d",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "João Henriques",
                    Email = "Henriques82648@email.com",
                    UserName = "João Henriques",
                    NormalizedEmail = "Henriques82648@email.com".ToUpper(),
                    NormalizedUserName = "João Henriques".ToUpper(),
                    Id = "0c88c53b-f18e-494e-88ff-1e9c2360f310",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Marcelo Ferreira",
                    Email = "MarceloFerreira@email.com",
                    UserName = "MarceloFerreira@email.com",
                    NormalizedEmail = "MarceloFerreira@email.com".ToUpper(),
                    NormalizedUserName = "MarceloFerreira@email.com".ToUpper(),
                    Id = "2db0257a-446d-4886-b46e-3f6246610080",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Gabriel Henriques",
                    Email = "GabHenriques@email.com",
                    UserName = "GabHenriques@email.com",
                    NormalizedEmail = "GabHenriques@email.com".ToUpper(),
                    NormalizedUserName = "GabHenriques@email.com".ToUpper(),
                    Id = "773922b7-74c3-4e4c-8097-fd7468ec8315",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "David Carvalho",
                    Email = "Carvalho69791@email.com",
                    UserName = "Carvalho69791@email.com",
                    NormalizedEmail = "Carvalho69791@email.com".ToUpper(),
                    NormalizedUserName = "Carvalho69791@email.com".ToUpper(),
                    Id = "db9792d7-d293-49b5-be8d-03ccf60d0e33",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Carolina Nogueira",
                    Email = "Nogueira@email.com",
                    UserName = "Nogueira@email.com",
                    NormalizedEmail = "Nogueira@email.com".ToUpper(),
                    NormalizedUserName = "Nogueira@email.com".ToUpper(),
                    Id = "e0585d26-607c-46d3-9eea-9c1c2708c7e1",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "João Fernando",
                    Email = "Fernando60603@email.com",
                    UserName = "Fernando60603@email.com",
                    NormalizedEmail = "Fernando60603@email.com".ToUpper(),
                    NormalizedUserName = "Fernando60603@email.com".ToUpper(),
                    Id = "10450067-5f19-44c7-8be1-388e8a6bdb30",
                    PasswordHash = hasher.HashPassword(null, "Medico1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }
            );

            //seed contas utilizadores
            modelBuilder.Entity<UtilizadorApp>().HasData(
                new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Isabela Bentes Teixeira",
                    Email = "teixeira@email.com",
                    UserName = "teixeira@email.com",
                    NormalizedEmail = "teixeira@email.com".ToUpper(),
                    NormalizedUserName = "teixeira@email.com".ToUpper(),
                    Id = "29f5f36e-5f11-42a2-b0b8-de7741c7de16",
                    PasswordHash = hasher.HashPassword(null, "Utente1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Leonardo Teves Dinis",
                    Email = "leonardo@email.com",
                    UserName = "leonardo@email.com",
                    NormalizedEmail = "leonardo@email.com".ToUpper(),
                    NormalizedUserName = "leonardo@email.com".ToUpper(),
                    Id = "a91d6e50-ec7a-442d-9278-4567dc61a0aa",
                    PasswordHash = hasher.HashPassword(null, "Utente1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Anabela Calçada Henriques Aveiro",
                    Email = "belaHenriques@email.com",
                    UserName = "belaHenriques@email.com",
                    NormalizedEmail = "belaHenriques@email.com".ToUpper(),
                    NormalizedUserName = "belaHenriques@email.com".ToUpper(),
                    Id = "18d7e29d-408f-42d7-9a27-ecc5d034d157",
                    PasswordHash = hasher.HashPassword(null, "Utente1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "João Celso Oliveira",
                    Email = "joaocelso@email.com",
                    UserName = "joaocelso@email.com",
                    NormalizedEmail = "joaocelso@email.com".ToUpper(),
                    NormalizedUserName = "joaocelso@email.com".ToUpper(),
                    Id = "5db04ccb-3be8-452f-b381-47bd2277fdca",
                    PasswordHash = hasher.HashPassword(null, "Utente1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }, new UtilizadorApp
                {
                    DataRegistro = DateTime.Now,
                    Nome = "Maria Inês Silva Henriques",
                    Email = "ineshenriques@email.com",
                    UserName = "ineshenriques@email.com",
                    NormalizedEmail = "ineshenriques@email.com".ToUpper(),
                    NormalizedUserName = "ineshenriques@email.com".ToUpper(),
                    Id = "db43e582-e359-421d-9192-1d3ad1a57737",
                    PasswordHash = hasher.HashPassword(null, "Utente1!"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }
            );

            //Seed Roles das contas
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "a", UserId = "a370779b-8777-4d3b-a96c-7a94d217e355" },
                new IdentityUserRole<string> { RoleId = "a", UserId = "93b9ebd2-3f4d-4009-8d8b-3a3404f85628" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "388c89b7-046e-414a-8212-1cced6e1aea1" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "b092ad4f-06b8-427f-bc38-cab75e79fc7d" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "0c88c53b-f18e-494e-88ff-1e9c2360f310" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "2db0257a-446d-4886-b46e-3f6246610080" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "773922b7-74c3-4e4c-8097-fd7468ec8315" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "db9792d7-d293-49b5-be8d-03ccf60d0e33" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "e0585d26-607c-46d3-9eea-9c1c2708c7e1" },
                new IdentityUserRole<string> { RoleId = "m", UserId = "10450067-5f19-44c7-8be1-388e8a6bdb30" },
                new IdentityUserRole<string> { RoleId = "u", UserId = "29f5f36e-5f11-42a2-b0b8-de7741c7de16" },
                new IdentityUserRole<string> { RoleId = "u", UserId = "a91d6e50-ec7a-442d-9278-4567dc61a0aa" },
                new IdentityUserRole<string> { RoleId = "u", UserId = "18d7e29d-408f-42d7-9a27-ecc5d034d157" },
                new IdentityUserRole<string> { RoleId = "u", UserId = "5db04ccb-3be8-452f-b381-47bd2277fdca" },
                new IdentityUserRole<string> { RoleId = "u", UserId = "db43e582-e359-421d-9192-1d3ad1a57737" }

            );

            // cria a seed das Especialidades
            modelBuilder.Entity<Especialidades>().HasData(
               new Especialidades { Id = 1, Nome = "Clínica Geral" },
               new Especialidades { Id = 2, Nome = "Cardiologia" },
               new Especialidades { Id = 3, Nome = "Dermatologia" },
               new Especialidades { Id = 4, Nome = "Neurologia" },
               new Especialidades { Id = 5, Nome = "Psiquiatria" },
               new Especialidades { Id = 6, Nome = "Cirurgia Geral" },
               new Especialidades { Id = 7, Nome = "Pediatria" },
               new Especialidades { Id = 8, Nome = "Pneumologia" }
            );


            // cria a seed dos Medicos
            modelBuilder.Entity<Medicos>().HasData(
                new Medicos
                {
                    Id = 1,
                    NumTelefone = "931111111",
                    Email = "cardoso@email.com",
                    Nome = "Natália Cardoso",
                    NumCedulaProf = "45485",
                    Foto = "45485.png",
                    DataNascimento = DateTime.ParseExact("04/04/1975", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "388c89b7-046e-414a-8212-1cced6e1aea1"
                },
                new Medicos
                {
                    Id = 2,
                    NumTelefone = "912222222",
                    Email = "Luizpaz59181@email.com",
                    Nome = "Luiz Fernando da Paz",
                    NumCedulaProf = "59181",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("17/02/1971", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "b092ad4f-06b8-427f-bc38-cab75e79fc7d"
                },
                new Medicos
                {
                    Id = 3,
                    NumTelefone = "963333333",
                    Email = "Henriques82648@email.com",
                    Nome = "João Henriques",
                    NumCedulaProf = "72648",
                    Foto = "72648.png",
                    DataNascimento = DateTime.ParseExact("17/04/1978", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "0c88c53b-f18e-494e-88ff-1e9c2360f310"
                },
                new Medicos
                {
                    Id = 4,
                    NumTelefone = "964444444",
                    Email = "MarceloFerreira@email.com",
                    Nome = "Marcelo Ferreira",
                    NumCedulaProf = "40603",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("04/06/1969", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "2db0257a-446d-4886-b46e-3f6246610080"
                },
                new Medicos
                {
                    Id = 5,
                    NumTelefone = "935555555",
                    Email = "GabHenriques@email.com",
                    Nome = "Gabriel Henriques",
                    NumCedulaProf = "45485",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("04/04/1975", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "773922b7-74c3-4e4c-8097-fd7468ec8315"
                },
                new Medicos
                {
                    Id = 6,
                    NumTelefone = "966666666",
                    Email = "Carvalho69791@email.com",
                    Nome = "David Carvalho",
                    NumCedulaProf = "69791",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("10/02/1974", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "db9792d7-d293-49b5-be8d-03ccf60d0e33"
                },
                new Medicos
                {
                    Id = 7,
                    NumTelefone = "937777777",
                    Email = "Nogueira@email.com",
                    Nome = "Carolina Nogueira",
                    NumCedulaProf = "82666",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("17/04/1981", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "e0585d26-607c-46d3-9eea-9c1c2708c7e1"
                },
                new Medicos
                {
                    Id = 8,
                    NumTelefone = "918888888",
                    Email = "Fernando60603@email.com",
                    Nome = "João Fernando",
                    NumCedulaProf = "60603",
                    Foto = "60603.png",
                    DataNascimento = DateTime.ParseExact("04/09/1976", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IdUtilizador = "10450067-5f19-44c7-8be1-388e8a6bdb30"
                }
            );


            //cria seed para atribuir aos medicos as suas especialidades
            //A tabela EspecialidadesMedicos foi criada automaticamente, não existe modelo, ListaMedicosId é o id do medico, ListaEspecialidadesId é o id da especialidade
            modelBuilder.Entity("EspecialidadesMedicos").HasData(
                new { ListaMedicosId = 1, ListaEspecialidadesId = 1 },
                new { ListaMedicosId = 1, ListaEspecialidadesId = 5 },
                new { ListaMedicosId = 1, ListaEspecialidadesId = 7 },
                new { ListaMedicosId = 2, ListaEspecialidadesId = 2 },
                new { ListaMedicosId = 3, ListaEspecialidadesId = 1 },
                new { ListaMedicosId = 4, ListaEspecialidadesId = 3 },
                new { ListaMedicosId = 5, ListaEspecialidadesId = 2 },
                new { ListaMedicosId = 6, ListaEspecialidadesId = 1 },
                new { ListaMedicosId = 6, ListaEspecialidadesId = 2 },
                new { ListaMedicosId = 7, ListaEspecialidadesId = 1 },
                new { ListaMedicosId = 1, ListaEspecialidadesId = 8 }
            );

            //cria seed dos Utentes
            modelBuilder.Entity<Utentes>().HasData(
                new Utentes
                {
                    Id = 1,
                    Nome = "Isabela Bentes Teixeira",
                    NumUtente = "111111111",
                    NIF = "270131221",
                    NumTelemovel = "911111111",
                    Email = "teixeira@email.com",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("07/02/1979", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Sexo = "F",
                    IdUtilizador = "29f5f36e-5f11-42a2-b0b8-de7741c7de16"
                }, new Utentes
                {
                    Id = 2,
                    Nome = "Leonardo Teves Dinis",
                    NumUtente = "222222222",
                    NIF = "244340862",
                    NumTelemovel = "932222222",
                    Email = "leonardo@email.com",
                    Foto = "222222222.png",
                    DataNascimento = DateTime.ParseExact("04/04/1988", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Sexo = "M",
                    IdUtilizador = "a91d6e50-ec7a-442d-9278-4567dc61a0aa"
                }, new Utentes
                {
                    Id = 3,
                    Nome = "Anabela Calçada Henriques Aveiro",
                    NumUtente = "333333333",
                    NIF = "290254388",
                    NumTelemovel = "933333333",
                    Email = "belaHenriques@email.com",
                    Foto = "333333333.png",
                    DataNascimento = DateTime.ParseExact("23/09/1968", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Sexo = "F",
                    IdUtilizador = "18d7e29d-408f-42d7-9a27-ecc5d034d157"
                }, new Utentes
                {
                    Id = 4,
                    Nome = "João Celso Oliveira",
                    NumUtente = "444444444",
                    NIF = "270131221",
                    NumTelemovel = "914444444",
                    Email = "joaocelso@email.com",
                    Foto = "semFoto.png",
                    DataNascimento = DateTime.ParseExact("08/09/1963", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Sexo = "M",
                    IdUtilizador = "5db04ccb-3be8-452f-b381-47bd2277fdca"
                }, new Utentes
                {
                    Id = 5,
                    Nome = "Maria Inês Silva Henriques",
                    NumUtente = "555555555",
                    NIF = "270131221",
                    NumTelemovel = "915555555",
                    Email = "ineshenriques@email.com",
                    Foto = "555555555.png",
                    DataNascimento = DateTime.ParseExact("12/04/1990", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Sexo = "F",
                    IdUtilizador = "db43e582-e359-421d-9192-1d3ad1a57737"
                }
            );

            //cria seed dos Diagnosticos-------------------------------------------------------------
            modelBuilder.Entity<Diagnosticos>().HasData(
                new Diagnosticos { Id = 1, Titulo = "Asma Brônquica", Descricao = "", Estado = "C" },
                new Diagnosticos { Id = 2, Titulo = "Aterosclerose", Descricao = "", Estado = "T" },
                new Diagnosticos { Id = 3, Titulo = "Gripe", Descricao = "", Estado = "F" }
             );

            //cria seed das Consultas-------------------------------------------------------------------
            modelBuilder.Entity<Consultas>().HasData(
                new Consultas
                {
                    Id = 1,
                    Data = DateTime.ParseExact("19/06/2022 09:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Dificuldade de Respiração",
                    Estado = "F",
                    MedicoFK = 1,
                    UtenteFK = 1,
                    DiagnosticoFK = 1
                }, new Consultas
                {
                    Id = 2,
                    Data = DateTime.ParseExact("25/06/2022 10:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Recetemente tive dores no peito e senti-me Fadigado",
                    Estado = "F",
                    MedicoFK = 2,
                    UtenteFK = 4,
                    DiagnosticoFK = 2
                }, new Consultas
                {
                    Id = 3,
                    Data = DateTime.ParseExact("26/06/2022 09:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Check up após Consulta anterior relativa a Dificuldade de Respiração",
                    Estado = "F",
                    MedicoFK = 1,
                    UtenteFK = 1,
                    DiagnosticoFK = 1
                }, new Consultas
                {
                    Id = 4,
                    Data = DateTime.ParseExact("26/06/2022 16:45", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Febre Alta",
                    Estado = "F",
                    MedicoFK = 2,
                    UtenteFK = 5,
                    DiagnosticoFK = 3
                }, new Consultas
                {
                    Id = 5,
                    Data = DateTime.ParseExact("01/07/2022 11:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Check up Anual",
                    Estado = "F",
                    MedicoFK = 1,
                    UtenteFK = 4,
                    DiagnosticoFK = null
                }, new Consultas
                {
                    Id = 6,
                    Data = DateTime.ParseExact("01/07/2022 17:15", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Check up Anual",
                    Estado = "C",
                    MedicoFK = 1,
                    UtenteFK = 5,
                    DiagnosticoFK = null
                }, new Consultas
                {
                    Id = 7,
                    Data = DateTime.ParseExact("29/07/2022 09:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Dores nos Pulsos",
                    Estado = "M",
                    MedicoFK = 6,
                    UtenteFK = 3,
                    DiagnosticoFK = null
                }, new Consultas
                {
                    Id = 8,
                    Data = DateTime.ParseExact("30/07/2022 09:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Motivo = "Check up Anual",
                    Estado = "P",
                    MedicoFK = 2,
                    UtenteFK = 2,
                    DiagnosticoFK = null
                }
             );

            //cria seed das Prescricoes--------------------------------------------------------------------------------------
            modelBuilder.Entity<Prescricoes>().HasData(
                new Prescricoes
                {
                    Id = 1,
                    Descricao = "Beclometasona quando for necessário, mínimo a cada 6 horas",
                    Estado = false,
                    DiagnosticoFK = 1,
                    Data = DateTime.ParseExact("19/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }, new Prescricoes
                {
                    Id = 2,
                    Descricao = "Estatinas à noite",
                    Estado = true,
                    DiagnosticoFK = 2,
                    Data = DateTime.ParseExact("25/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }, new Prescricoes
                {
                    Id = 3,
                    Descricao = "Formoterol duas vezes ao dia, de manhã e de noite",
                    Estado = true,
                    DiagnosticoFK = 1,
                    Data = DateTime.ParseExact("26/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }
            );

            //cria seed dos Pagamentos
            modelBuilder.Entity<Pagamentos>().HasData(
                new Pagamentos
                {
                    Id = 1,
                    Descricao = "Taxa Moderadora",
                    Valor = 12.5M,
                    Estado = true,
                    Metodo = "MB",
                    ConsultaFK = 1,
                    DataEfetuado = DateTime.ParseExact("19/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }, new Pagamentos
                {
                    Id = 2,
                    Descricao = "Raio-X",
                    Valor = 15,
                    Estado = true,
                    Metodo = "MB",
                    ConsultaFK = 1,
                    DataEfetuado = DateTime.ParseExact("25/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }, new Pagamentos
                {
                    Id = 3,
                    Descricao = "Taxa Moderadora",
                    Valor = 12.5M,
                    Estado = true,
                    Metodo = "D",
                    ConsultaFK = 2,
                    DataEfetuado = DateTime.ParseExact("25/08/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }, new Pagamentos
                {
                    Id = 4,
                    Descricao = "Exames Laboratoriais",
                    Valor = 35.62M,
                    Estado = true,
                    Metodo = "D",
                    ConsultaFK = 4,
                    DataEfetuado = DateTime.ParseExact("25/08/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                }, new Pagamentos
                {
                    Id = 5,
                    Descricao = "Taxa Moderadora",
                    Valor = 12.5M,
                    Estado = false,
                    Metodo = null,
                    ConsultaFK = 3,
                    DataEfetuado = null
                }, new Pagamentos
                {
                    Id = 6,
                    Descricao = "Taxa Moderadora",
                    Valor = 12.5M,
                    Estado = false,
                    Metodo = null,
                    ConsultaFK = 4,
                    DataEfetuado = null
                }, new Pagamentos
                {
                    Id = 7,
                    Descricao = "Taxa Moderadora",
                    Valor = 12.5M,
                    Estado = false,
                    Metodo = null,
                    ConsultaFK = 5,
                    DataEfetuado = null
                }
            );
        }



        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Diagnosticos> Diagnosticos { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<Prescricoes> Prescricoes { get; set; }
        public DbSet<Utentes> Utentes { get; set; }



    }
}