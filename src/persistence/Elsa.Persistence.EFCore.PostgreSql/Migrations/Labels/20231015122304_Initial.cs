﻿
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elsa.Persistence.EFCore.PostgreSql.Migrations.Labels
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        private readonly IElsaDbContextSchema _schema;
        public Initial(IElsaDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: _schema.Schema);

            migrationBuilder.CreateTable(
                name: "Labels",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NormalizedName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowDefinitionLabels",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    WorkflowDefinitionId = table.Column<string>(type: "text", nullable: false),
                    WorkflowDefinitionVersionId = table.Column<string>(type: "text", nullable: false),
                    LabelId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowDefinitionLabels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "WorkflowDefinitionLabel_LabelId",
                schema: _schema.Schema,
                table: "WorkflowDefinitionLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "WorkflowDefinitionLabel_WorkflowDefinitionId",
                schema: _schema.Schema,
                table: "WorkflowDefinitionLabels",
                column: "WorkflowDefinitionId");

            migrationBuilder.CreateIndex(
                name: "WorkflowDefinitionLabel_WorkflowDefinitionVersionId",
                schema: _schema.Schema,
                table: "WorkflowDefinitionLabels",
                column: "WorkflowDefinitionVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labels",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "WorkflowDefinitionLabels",
                schema: _schema.Schema);
        }
    }
}
