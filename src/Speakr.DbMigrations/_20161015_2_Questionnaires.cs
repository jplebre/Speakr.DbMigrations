using FluentMigrator;
using System;

namespace Speakr.DbMigrations
{
    [Migration(2)]
    public class _20161015_2_Questionnaires : Migration
    {
        public override void Up()
        {
            Create.Table("Questionnaires")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Questionnaire").AsString(Int32.MaxValue);

            Create.Table("Feedback")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("TalkId").AsGuid().NotNullable()
                .WithColumn("Answer").AsString(Int32.MaxValue);

            Create.Column("QuestionnaireId").OnTable("Talks").AsInt64()
                .ForeignKey("Questionnaires", "Id");
        }

        public override void Down()
        {
            Delete.Column("QuestionnaireId").FromTable("Talks");

            Delete.Table("Questionnaires");
            Delete.Table("Feedback");
        }
    }
}
