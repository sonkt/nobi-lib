using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c8b9c569-2592-4e3f-bf08-01bfd76d0e66"), "LIE", null, "Liechtenstein", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("54d0073f-1e24-45dd-a614-02f3824db494"), "BEN", null, "Benin", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b32a4d67-abd8-4763-93d2-033abced9bed"), "MAR", null, "Morocco", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5bf1a7d9-1077-4bb7-a30b-03645eafd546"), "FJI", null, "Fiji", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("1717bdc8-53e8-4cf8-b571-04141e5608af"), "GMB", null, "Gambia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("603e2feb-b866-4587-a774-0437f0f117c6"), "NCL", null, "New Caledonia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("13f8519b-9827-4e34-95b5-066c1455d9c6"), "MOZ", null, "Mozambique", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("57c7c358-568a-48b5-bc07-08098ea9ecf6"), "ALB", null, "Albania", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2f3d5d2a-bb2b-4a52-bff2-089ec1cd228e"), "ASM", null, "American Samoa", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5d9450fd-feb5-4653-8b37-09840905bec5"), "MKD", null, "Macedonia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5eba2d43-adaf-4f4b-8175-09e3935c1f8b"), "NRU", null, "Nauru", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("775baa8e-13bd-4677-905f-0afd90953298"), "TJK", null, "Tajikistan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4741e18e-f403-4a8e-9312-0d6ca9a564b9"), "AIA", null, "Anguilla", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("8dd14c56-f145-48ac-8f29-0e7dc387c6c6"), "VEN", null, "Venezuela", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("8eceed2c-9f64-4ab4-bbd8-0f41c0ab694a"), "BDI", null, "Burundi", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7060374e-c1c7-4c09-88fb-0fe8580a2b7a"), "COM", null, "Comoros", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("44f9ebfe-3d40-4725-8dca-1073d4b32d44"), "UKR", null, "Ukraine", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2a799ccb-cea9-4927-964e-10bf1af66824"), "AZE", null, "Azerbaijan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("93dbe5f6-b78a-4676-95ec-119afa96471e"), "VCT", null, "Saint Vincent and the Grenadines", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b607215c-17b6-441b-a4e3-132a75716d88"), "KIR", null, "Kiribati", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e8e17ac0-99bf-4401-8d4b-14346033de32"), "ECU", null, "Ecuador", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("1a8841b5-ba08-4def-8371-145aa2bf09b9"), "TKM", null, "Turkmenistan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("946e35ed-940c-4206-a14f-14a53b16e2b5"), "DOM", null, "Dominican Republic", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4bcc58bb-04db-4138-bbd3-1594db4bc990"), "BLZ", null, "Belize", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("51cb4409-51dc-48ec-a1fb-163ed47ba298"), "GIB", null, "Gibraltar", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e5c783be-3af3-4063-ba67-1900f389c2e7"), "KNA", null, "Saint Kitts and Nevis", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("171dfa14-5d0b-43af-9e7a-196ef6359730"), "PER", null, "Peru", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("242849fd-66c2-44f5-85bd-1a74e52c66b1"), "POL", null, "Poland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("acf38f19-ed31-4c12-ac87-1bbe44d98d23"), "ANT", null, "Netherlands Antilles", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("34fc10e6-5e18-46fb-af94-1bfe2c97eaae"), "ZAF", null, "South Africa", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f5a6e3c9-1965-4d0b-9784-1cb3287e71f0"), "GGY", null, "Guernsey", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("04cbbc86-e1c4-4da1-acc0-1f8485bb378f"), "REU", null, "Reunion", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("6d046db5-6770-41ac-8f0d-1fed1a1ecda1"), "TUR", null, "Turkey", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0f5f55f7-3281-4ebb-bef7-226101f730b2"), "ITA", null, "Italy", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("60d88cdf-4431-41ea-92b7-2360cbd1dfbc"), "PRI", null, "Puerto Rico", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("09d8294c-7e32-4375-8c76-258a57f165fe"), "AND", null, "Andorra", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4391f0b3-c311-43e4-a425-25f1de47f834"), "IMN", null, "Isle of Man", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e8aeaa80-38b6-4d85-9805-268d66b21f29"), "IRN", null, "Iran", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("666f8a7a-ceb5-4644-882a-2709500d735b"), "VUT", null, "Vanuatu", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9158d1fc-c9f3-4ba4-9d63-27c3876031e5"), "PNG", null, "Papua New Guinea", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("1845eadd-85d4-4c98-b884-2ac4e709fdea"), "CAF", null, "Central African Republic", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d8d52645-2e37-4c0b-866e-2b3be3292bbc"), "CZE", null, "Czech Republic", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("83546401-9541-4409-8947-2c0dc4aceeca"), "TCD", null, "Chad", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e5d7302d-4e43-4091-802f-2c1ccd9608b5"), "GIN", null, "Guinea", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("fac224cb-91b4-407c-bf08-2d260c2ffac2"), "SWE", null, "Sweden", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("1a0979f7-5757-4ec2-9b62-2de22f9e6e06"), "SHN", null, "Saint Helena", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("ca40eece-9c66-4a98-b9ea-2f8512d3f954"), "GUY", null, "Guyana", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9fa00ceb-8399-469a-a865-306f91bcd869"), "MDA", null, "Moldova", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7a2dca18-d26e-4fb2-9b53-31268550ea34"), "LAO", null, "Laos", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("895ea71a-4864-4848-8b96-318b8e9cb2ce"), "LBN", null, "Lebanon", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e0645e7e-bbf3-4d43-8221-31f903d37a56"), "SLB", null, "Solomon Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f0445be8-e7e3-4134-af3e-3422ac87c2aa"), "SPM", null, "Saint Pierre and Miquelon", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("ea607f2c-1037-4056-ae78-34e9a959b859"), "VIR", null, "U.S. Virgin Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("06e3aead-e451-4a5b-89bd-35dceb50f9de"), "COD", null, "Democratic Republic of the Congo", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("63af1e5d-4cd2-4da0-ae67-35de331bd551"), "GNB", null, "Guinea-Bissau", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("8c4371b2-f765-4ca2-9801-35e998d0575d"), "CYP", null, "Cyprus", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("904e04f6-b46a-4475-8757-36036c488e8e"), "PAN", null, "Panama", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0d7ab1aa-b4b6-48ae-ab09-3959cd290163"), "BFA", null, "Burkina Faso", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("444a40da-7771-40d3-b7d2-39ee2e8fc6b9"), "GBR", null, "United Kingdom", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("bd0102f9-e814-414e-9c64-3a733f4eb826"), "DJI", null, "Djibouti", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9554e6a0-ac28-42c6-92a4-3b34fbe14d6b"), "COK", null, "Cook Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("a735622e-ca2d-48da-969c-3c41ec933965"), "MLI", null, "Mali", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e45a86d6-8abf-4781-9b90-3db37fc20b44"), "ARE", null, "United Arab Emirates", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("99a8a912-4444-4457-a274-3f4c90128182"), "CUW", null, "Curacao", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2eb78ea7-523e-41b6-a52a-4199f276fcc0"), "MYS", null, "Malaysia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4ea82d45-4475-4522-9e66-41b00f694c13"), "AFG", null, "Afghanistan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5f0cba01-26e0-48e0-b18a-428a4cdb2735"), "MDG", null, "Madagascar", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b0b519cc-8c26-46a1-9528-4351718326ac"), "YEM", null, "Yemen", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("bcd15c92-9720-4c7b-a7b5-44a9dc7c46a4"), "PCN", null, "Pitcairn", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("64d55d1f-7099-4818-b769-457ea1e79476"), "EST", null, "Estonia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4fd928a1-1d27-4d4e-a2c4-4585b78bea6d"), "RWA", null, "Rwanda", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d55d7634-7a1c-4732-bd31-464996c52cef"), "IDN", null, "Indonesia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("84d75e2d-4879-4d84-aa32-46656366d982"), "BRB", null, "Barbados", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("8f9c76bb-fc02-4981-95dc-4a6492bb4d01"), "PLW", null, "Palau", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("6541d1fd-d6e2-4b8d-8bdd-4a84792d8d1f"), "TWN", null, "Taiwan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("630d1db2-c9aa-4494-8270-4af1d139721f"), "LBY", null, "Libya", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("475d56d5-629f-4884-87ab-4b6c85526377"), "AGO", null, "Angola", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("968c0069-1390-41fe-8550-4b9bf31b9b63"), "DMA", null, "Dominica", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e5597e5d-c1ed-4de6-8167-4bc2fbc8d37e"), "PYF", null, "French Polynesia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5a637cbd-bf7b-4fc1-bc9c-4ca9462afdfe"), "MNP", null, "Northern Mariana Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("91ee9ddc-44e9-4e73-bccd-4cdc1b97a91f"), "PRK", null, "North Korea", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d9277de0-470c-4645-93e9-4d4f4bcb3518"), "HTI", null, "Haiti", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("fbdde69f-8e8b-452a-86a9-4e176e2bf246"), "MWI", null, "Malawi", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("64251759-6985-4d37-9159-4eaa11e66a91"), "MUS", null, "Mauritius", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b1339d9f-3a02-4e00-b602-509e323f9e6b"), "NGA", null, "Nigeria", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3edf0dfa-2e95-4bcf-8c5e-50abf6551543"), "KAZ", null, "Kazakhstan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f767d720-8beb-4828-802e-513e7b517d7c"), "ZMB", null, "Zambia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("dcb9a910-4595-4f3a-a3a2-53918eafd918"), "LUX", null, "Luxembourg", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("6257ca86-193e-4e33-86e9-547187204d97"), "GTM", null, "Guatemala", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("56178390-fa0d-4e42-8f5a-55b154acb676"), "NIU", null, "Niue", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e3250495-9613-4924-a3e8-564010d2fbde"), "EGY", null, "Egypt", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("181f58bb-a6ea-4e07-8077-57eb4b9a14a2"), "MAF", null, "Saint Martin", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7854f7cc-eef4-418d-bedc-5bd0fc740918"), "BIH", null, "Bosnia and Herzegovina", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("60f820a6-f5ec-405f-ad9f-605dd2fe7b6b"), "JOR", null, "Jordan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b311facf-a869-4704-9cae-608135697aca"), "NER", null, "Niger", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("86e2fe29-6922-43f7-9ae7-613755e60c22"), "DNK", null, "Denmark", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5e9968ef-48b1-4ec6-8cb1-61df82672cda"), "BRN", null, "Brunei", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("6c02f88f-d243-4b00-b09f-61f1930c1351"), "XKX", null, "Kosovo", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e299544c-0e6f-4462-afdf-6359c79fed53"), "UZB", null, "Uzbekistan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d358eb32-b935-4294-8fbb-63a6bbce0939"), "ISR", null, "Israel", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d21102c5-6503-4ce9-bd57-63fcba692881"), "SVN", null, "Slovenia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b890020b-c69f-4da3-a0e7-64790c34d18c"), "TCA", null, "Turks and Caicos Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d394132d-b4f6-4178-89f4-653faf15d73b"), "GEO", null, "Georgia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c5b068b0-45e3-403a-98ac-6552e943a98c"), "PHL", null, "Philippines", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f233ff3c-0844-49e0-b175-660f5447c874"), "SYC", null, "Seychelles", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("52e625a1-e274-4960-8130-6657b5440ff1"), "TKL", null, "Tokelau", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("a9c21fdb-1542-4b12-8646-6659cf13d46a"), "GNQ", null, "Equatorial Guinea", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3ce8cc5c-6e4d-4320-b59f-68c766b0898a"), "ROU", null, "Romania", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("a3dec1f6-5538-46bd-a378-69c82bc6fb57"), "MRT", null, "Mauritania", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9028b474-237d-4815-8704-6c92c95498bc"), "MHL", null, "Marshall Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5d82e5b1-d033-4380-913d-70a2f9ecaf8f"), "TGO", null, "Togo", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("a870786c-3590-4c7d-bb78-70f2f8c5eea4"), "AUT", null, "Austria", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b4c3adbb-784c-45c4-ae75-73a8f6e4fb06"), "SWZ", null, "Swaziland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("40be3f49-ad51-4e69-bbc0-73f1b60ec270"), "JPN", null, "Japan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("24f05eb5-1206-406b-b101-75bf691f5455"), "COL", null, "Colombia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("ae52c3c0-fe6e-4aa0-bc41-766a8b9f54bd"), "CHN", null, "China", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9750063f-7129-429e-b534-769b016b5715"), "FRO", null, "Faroe Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("1efc282c-630e-4a09-b59e-772012d0cf05"), "PRT", null, "Portugal", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3a087e7f-0283-4f57-bd30-7831ec1c9b1c"), "TZA", null, "Tanzania", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9683a538-abd5-4a36-b606-79fb8c7150db"), "SUR", null, "Suriname", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("6bc98dfe-f492-4443-8841-7ffaf532d764"), "NPL", null, "Nepal", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f72bb2bf-7c32-4f2b-9e65-813cd1b4dbbc"), "USA", null, "United States", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("36716a1b-ec05-49ee-8ac7-815a3933794e"), "IRQ", null, "Iraq", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("811a3609-3033-4e39-ae16-81750d16713c"), "HND", null, "Honduras", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7d69e95f-eb83-404c-a4db-818f9b2f48f1"), "LSO", null, "Lesotho", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("081c1c9f-4079-483e-9274-81b0593c6e2e"), "KHM", null, "Cambodia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4eef688c-a661-445f-a6ab-82634241500b"), "BTN", null, "Bhutan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9d89d56b-0dd6-4d55-a7ca-82738862e1bc"), "CHE", null, "Switzerland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("df8bf99a-4b69-43b2-a90e-829641289d5e"), "CRI", null, "Costa Rica", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("33f60433-b69e-4276-9e54-85b5c2253784"), "IRL", null, "Ireland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5343d3e8-aa89-48b1-a579-860e112c6ac1"), "IOT", null, "British Indian Ocean Territory", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3d1853e7-1349-4f73-b56e-87629cae52b2"), "ERI", null, "Eritrea", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("754e6c6f-31a2-4da8-8374-87eaf0551260"), "NIC", null, "Nicaragua", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f98e5b58-27e6-4c88-87cc-88c4390d07c4"), "FSM", null, "Micronesia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("74d42bcb-f827-4b5e-ad1b-896dde5ffe42"), "SXM", null, "Sint Maarten", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("482a74cc-3b9f-454a-a2f9-8b936d3c0ba2"), "PRY", null, "Paraguay", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2a6eb98b-cda8-46df-81e6-8c1726c00d49"), "VNM", null, "Vietnam", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("aa353b9d-9ff6-48a6-8f34-8d59893d9661"), "TUN", null, "Tunisia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("eb9b955c-1ee9-4460-83fc-8d64dc469b57"), "SJM", null, "Svalbard and Jan Mayen", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9d0255c2-ce21-494f-8914-8d7156cf8584"), "SGP", null, "Singapore", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("a959b5bd-d043-455a-98a0-8fa1e19ede2b"), "WLF", null, "Wallis and Futuna", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("810b9676-40cb-4b61-9ba3-900fd43bc6f3"), "KGZ", null, "Kyrgyzstan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("309d706f-c223-405b-b18d-92024bd8c264"), "SRB", null, "Serbia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0c76be36-0961-4488-a5d0-92d4490be7da"), "DEU", null, "Germany", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("882baa84-6ad9-463f-913c-92f86103f37d"), "CPV", null, "Cape Verde", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("ec710938-436b-4dad-bcc7-959934a096b2"), "JAM", null, "Jamaica", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("407b3e95-0d06-40a5-b84b-96240590e0c7"), "VGB", null, "British Virgin Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5eb0d353-2878-4dc9-b421-9672db842875"), "SDN", null, "Sudan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3b2f6ee5-69a5-4c1c-801b-9748d570cd88"), "ARM", null, "Armenia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("705e7a14-86ba-42dd-814b-97a7c7f617fe"), "KOR", null, "South Korea", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0bbc46ea-f01a-4408-83ee-9887c112630a"), "SMR", null, "San Marino", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f7655605-a735-4748-bfb7-98f23202cb00"), "BWA", null, "Botswana", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("1d632ff2-dde1-48a1-9456-990f050888f3"), "MSR", null, "Montserrat", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("ebd18848-84d1-4e86-9163-998e4f51a813"), "ZWE", null, "Zimbabwe", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("29b15394-e837-4723-99af-9af8be7d8199"), "ARG", null, "Argentina", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("bc33b5dc-07a7-4eb5-8df9-9b50becff5f2"), "WSM", null, "Samoa", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9b2ca50a-5a35-45d4-8bb4-9bf1bb67be1b"), "NZL", null, "New Zealand", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("507d0484-614c-416b-8627-9cf0120023bd"), "URY", null, "Uruguay", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0885f74a-5810-4006-a2db-9dce2db3ef05"), "MMR", null, "Myanmar", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3a6a8897-3c90-4225-a8b7-9ecf798096a9"), "IND", null, "India", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("4f282566-fca3-47cd-be33-9ff5e36871ce"), "GHA", null, "Ghana", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("5ba7b586-d76d-4cef-a42e-a05261e7512c"), "GRD", null, "Grenada", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("04de1370-678c-471f-880b-a18e8662fcb5"), "LCA", null, "Saint Lucia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3cd30c30-0933-40d9-8800-a1db7ae086d9"), "CYM", null, "Cayman Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("217c2945-dcb0-4d16-afe7-a278f5257681"), "FIN", null, "Finland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9280a2a5-b183-451c-80ba-a2eac0134f56"), "CXR", null, "Christmas Island", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("913384bf-0a11-4679-baba-a3ddbf27ebd4"), "SAU", null, "Saudi Arabia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2346d497-1dcd-4b21-a66d-a6a67ccf5ee8"), "ESP", null, "Spain", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7907e98d-2dff-4f13-bb0e-ab5a78cdc140"), "SLE", null, "Sierra Leone", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b332a0ca-478f-48de-8cc4-abdcfdd51f3f"), "CUB", null, "Cuba", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("cbaf3fdf-82eb-4bde-9d86-aca5b1e20187"), "BMU", null, "Bermuda", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("863bd7aa-5643-4681-ba7d-acfd857bc005"), "RUS", null, "Russia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("334b3512-a87f-4865-aafc-ad16396e1c05"), "ESH", null, "Western Sahara", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("210d43b8-bfcf-4892-a3b4-afdc097181ff"), "BHR", null, "Bahrain", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b9bf39ab-b502-4680-a5e8-b12bee8d988c"), "KEN", null, "Kenya", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9c6b7c93-3c33-4f85-beb4-b166f8d1eeb5"), "SSD", null, "South Sudan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c6eccd66-1e6d-414b-9013-b274705ae487"), "BLM", null, "Saint Barthelemy", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b737f9ad-36e9-4f72-8901-b3534e773ad1"), "ETH", null, "Ethiopia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("828039c9-2bd1-413e-a3c8-b5adda0ad534"), "SEN", null, "Senegal", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2469e675-90ff-4da5-822c-b7d5adeb3dc5"), "FLK", null, "Falkland Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("26ae05b5-3988-41f0-9c4a-b851e325abe0"), "VAT", null, "Vatican", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2f2542df-ae90-4050-ba2d-b9b34ac31aea"), "JEY", null, "Jersey", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f770d1f7-602f-4dc5-aab6-bbac2693c43b"), "MNE", null, "Montenegro", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("33b08d04-7c1f-4e5c-845d-bceb48b8049e"), "BHS", null, "Bahamas", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("175e6587-9d2b-40a8-a942-bed1721e408a"), "BRA", null, "Brazil", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7f90a318-2a2b-4b8b-a3f5-bf0833ea1f2d"), "BGD", null, "Bangladesh", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3d9ccb06-cf28-4734-a74a-bf444a1878c2"), "GAB", null, "Gabon", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e4c99d64-05e3-4bdd-ad2f-bf459c190f43"), "CMR", null, "Cameroon", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("7fdd1f18-d5b2-458b-8932-c01f6b7acc1e"), "CHL", null, "Chile", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2857dae6-be3b-4ec7-9637-c12ecf1b1ee5"), "SVK", null, "Slovakia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b4bab627-8b88-4490-a0e2-c198b40caaec"), "PSE", null, "Palestine", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("18ccfe8c-e291-4024-8c20-c212d1209d6d"), "CAN", null, "Canada", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("03f74f35-fa3e-47ac-9430-c21ed226c0f0"), "KWT", null, "Kuwait", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e8899c72-1310-40be-bc38-c3336f958cf3"), "AUS", null, "Australia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0e4ee00f-3f0f-40b4-b88a-c5075423b425"), "ATA", null, "Antarctica", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("fa7386c4-48ad-43ea-b54f-c7f2efd62e54"), "COG", null, "Republic of the Congo", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("77c1bb60-88c8-4a8a-ad3f-c80613731c71"), "CCK", null, "Cocos Islands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("eb349dea-3846-4b49-9abd-c8d9afb9f564"), "MLT", null, "Malta", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3b6a6dbb-44d9-416f-b97c-c8ed7705b8b5"), "MNG", null, "Mongolia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2f6730c7-a804-4a41-a07b-c93488178076"), "CIV", null, "Ivory Coast", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b5061aa3-8045-46dd-86d5-ccab80205ed4"), "MDV", null, "Maldives", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("80212715-0e7e-415c-bea6-ccaec7e788f4"), "PAK", null, "Pakistan", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d488db94-c4f7-414e-abe2-cceb8bca1853"), "TON", null, "Tonga", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("25888da5-8a90-48d6-b304-cd993843a8ed"), "GRL", null, "Greenland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c31da903-ff35-4353-bcee-cdfa92c484b0"), "BGR", null, "Bulgaria", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("749a1670-1f28-47f1-b2ba-cf318e192d90"), "LTU", null, "Lithuania", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2d1ede3b-47b8-4922-96f7-d0fb89e5f384"), "THA", null, "Thailand", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("01ec4f6b-faca-4e6e-ada9-d127d4db3db4"), "TUV", null, "Tuvalu", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("025c9c43-f55e-4f45-a9c2-d1a36b0f1660"), "STP", null, "Sao Tome and Principe", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("871556b0-af6a-4b3d-bc8c-d3bfeff8fc6b"), "NOR", null, "Norway", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2790acca-f464-42a5-aa29-d3e23364933b"), "ISL", null, "Iceland", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("42941584-13d2-4a13-a0f0-d5a9778921f3"), "HKG", null, "Hong Kong", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c22e1316-8f06-4faf-b1a7-d5f4d9b4167b"), "LVA", null, "Latvia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d6786ddc-2fa1-4df6-9717-d8719b164eef"), "NAM", null, "Namibia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d129db5c-98eb-49cc-8200-dadf5101e29d"), "HRV", null, "Croatia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("2937cc30-2b78-4e10-83c4-dcf451f7cb4d"), "GUM", null, "Guam", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c3b7a308-c66f-47f1-a30e-dd16e65231c7"), "DZA", null, "Algeria", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("dc4234ff-35b7-43d3-9d15-dd3faab4657b"), "TTO", null, "Trinidad and Tobago", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("d8d9b623-a407-4e5b-975a-ddeb61060bdd"), "ATG", null, "Antigua and Barbuda", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("c09eeeb4-85d4-4ca0-bc93-e548a65c918f"), "ABW", null, "Aruba", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3f52a3a2-9ec7-4d8d-b354-e6000cb0ae66"), "FRA", null, "France", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("ee1c5148-9031-499c-ba4b-e60dc66c5895"), "SLV", null, "El Salvador", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("3ce8e4a5-171f-4805-9146-e68707cc3060"), "MCO", null, "Monaco", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("dacd996a-673a-44f5-8622-eae8e3b4f1c2"), "MAC", null, "Macau", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("b49b5767-f1eb-4f4b-a242-ec5dc614a993"), "BEL", null, "Belgium", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0f10b570-d0f7-46d7-92bd-ed74e6fa1d9d"), "SYR", null, "Syria", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f8e1ae91-aed4-4c7e-9bcf-f15373f5cb7e"), "UGA", null, "Uganda", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("98f1d6dc-ac6f-4867-a840-f1c93831cd67"), "LKA", null, "Sri Lanka", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("f0dddae6-f52f-488a-8604-f26134a9c499"), "OMN", null, "Oman", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9f10cc70-03fd-43c8-b23a-f4628f9ccd80"), "GRC", null, "Greece", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e3bb1ae2-d3dc-4f6f-890f-f677769f140e"), "TLS", null, "East Timor", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e08cf2b7-4243-433d-a2a2-f67810ef18b8"), "BLR", null, "Belarus", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("9d9d04b9-1230-40f9-9bb8-f74df8ea3365"), "LBR", null, "Liberia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e808103a-d4e1-4288-8d73-f8e247b6105c"), "NLD", null, "Netherlands", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("bee9f4ae-8c19-433b-91dd-f9c74061067e"), "MYT", null, "Mayotte", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("8c9f9ba6-1e1d-4da7-8406-fc1bfaab3d6c"), "MEX", null, "Mexico", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("e259d78a-fed6-4391-95bb-fc5ab16a5364"), "HUN", null, "Hungary", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("0d4aae3f-fd1b-41c0-938d-fd909db7468a"), "BOL", null, "Bolivia", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );

            migrationBuilder.InsertData(
            table: "TestEntities",
            columns: new[] { "PK_TestEntityID", "TestCode", "Description", "TestName", "IsDeleted", "CreatedDate", "CreatedUser", "UpdatedDate", "UpdatedUser", "DeletedDate", "DeletedUser" },
            values: new object[] { Guid.Parse("17465073-8a18-4dcd-b4ae-feba404456f7"), "QAT", null, "Qatar", false, DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), DateTime.Now, Guid.Parse("aec56ec7-0188-41bd-a36a-a8675a380862"), null, null }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"TRUNCATE TABLE TestEntities");
        }
    }
}
