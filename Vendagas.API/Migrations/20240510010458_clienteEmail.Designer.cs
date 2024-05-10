﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vendagas.API.ORM.Context;

#nullable disable

namespace Vendagas.API.Migrations
{
    [DbContext(typeof(VendagasContext))]
    [Migration("20240510010458_clienteEmail")]
    partial class clienteEmail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Vendagas.API.ORM.Entity.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClienteName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Vendagas.API.ORM.Entity.EmpresaModel", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EmpresaId");

                    b.HasIndex("UserId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Vendagas.API.ORM.Entity.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Vendagas.API.ORM.Entity.ClienteModel", b =>
                {
                    b.HasOne("Vendagas.API.ORM.Entity.EmpresaModel", "Empresa")
                        .WithMany("Cliente")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Vendagas.API.ORM.Entity.EmpresaModel", b =>
                {
                    b.HasOne("Vendagas.API.ORM.Entity.UserModel", "User")
                        .WithMany("Empresa")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vendagas.API.ORM.Entity.EmpresaModel", b =>
                {
                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Vendagas.API.ORM.Entity.UserModel", b =>
                {
                    b.Navigation("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}
