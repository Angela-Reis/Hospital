﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using System.Globalization;

namespace Hospital.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // importa a execução previa do método
            base.OnModelCreating(modelBuilder);

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
                new { ListaMedicosId = 7, ListaEspecialidadesId = 1 }
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
                    Sexo = "F"
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
                    Sexo = "M"
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
                    Sexo = "F"
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
                    Sexo = "M"
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
                    Sexo = "F"
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