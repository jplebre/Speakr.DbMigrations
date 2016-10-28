using FluentMigrator;

namespace Speakr.DbMigrations
{
    [Migration(1)]
    public class _20161015_1_Talks : Migration
    {
        public override void Up()
        {
            Create.Table("Talks")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("EasyAccessKey").AsString(32).NotNullable()
                .WithColumn("Name").AsString()
                .WithColumn("Topic").AsString()
                .WithColumn("Description").AsString()
                .WithColumn("SpeakerName").AsString()
                .WithColumn("TalkCreationTime").AsDateTime().NotNullable()
                .WithColumn("TalkStartTime").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Talks");
        }
    }
}
