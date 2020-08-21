namespace MovieCustomerMvcAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Membershiptypes(SignUpFree,DurationInMonths,DiscountRate)values(0,0,0)");
            Sql("insert into Membershiptypes(SignUpFree,DurationInMonths,DiscountRate)values(30,1,10)");
            Sql("insert into Membershiptypes(SignUpFree,DurationInMonths,DiscountRate)values(90,3,15)");
            Sql("insert into Membershiptypes(SignUpFree,DurationInMonths,DiscountRate)values(300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
