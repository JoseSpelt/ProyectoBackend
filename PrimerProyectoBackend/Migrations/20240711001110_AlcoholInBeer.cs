﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimerProyectoBackend.Migrations
{
    /// <inheritdoc />
    public partial class AlcoholInBeer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Alcohol",
                table: "Beers",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "Beers");
        }
    }
}
