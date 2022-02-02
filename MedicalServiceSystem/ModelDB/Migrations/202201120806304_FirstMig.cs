namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApproveDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApproveId = c.Int(nullable: false),
                        ApproveNo = c.String(),
                        ServiceId = c.Int(nullable: false),
                        ApproveCost = c.Decimal(precision: 18, scale: 2),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        Diff = c.Decimal(precision: 18, scale: 2),
                        Sessions = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approves", t => t.ApproveId, cascadeDelete: false)
                .ForeignKey("dbo.MedicalServices", t => t.ServiceId, cascadeDelete: false)
                .Index(t => t.ApproveId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Approves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApproveNo = c.String(),
                        InsurId = c.Int(nullable: false),
                        ReqCenterId = c.Int(nullable: false),
                        ExcCenterId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                        ApproveDate = c.DateTime(nullable: false),
                        ApproveYear = c.Int(nullable: false),
                        ApproveMonth = c.Int(nullable: false),
                        AttendenceReason = c.String(),
                        ExceptionReason = c.String(),
                        OtherExceptions = c.String(),
                        Uploaded = c.Boolean(),
                        Answered = c.Boolean(),
                        UnderProcess = c.Boolean(),
                        Printed = c.Boolean(),
                        IsEngaged = c.Boolean(),
                        EngeDate = c.DateTime(nullable: false),
                        EngeTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(),
                        InContract = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localities", t => t.LocalityId, cascadeDelete: false)
                .ForeignKey("dbo.Subscribers", t => t.InsurId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.InsurId)
                .Index(t => t.UserId)
                .Index(t => t.LocalityId);
            
            CreateTable(
                "dbo.Localities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalityName = c.String(),
                        LocalityLetter = c.String(),
                        LocalityIP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNo = c.String(),
                        InsurNo = c.String(),
                        InsurName = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Server = c.String(),
                        ClientId = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        IsStoped = c.Boolean(),
                        Notes = c.String(),
                        localityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPass = c.String(),
                        FullName = c.String(),
                        GroupId = c.Int(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        Image = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserGroups", t => t.GroupId, cascadeDelete: false)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalServices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SubGroupID = c.Int(nullable: false),
                        ServiceEName = c.String(),
                        ServiceAName = c.String(),
                        ServiceEmPrice = c.Decimal(precision: 18, scale: 2),
                        ServicePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceFrequency = c.Int(),
                        Duration = c.Int(),
                        ListType = c.Int(nullable: false),
                        NeedApproveMent = c.Boolean(),
                        InContract = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(),
                        Sessions = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalSubGroups", t => t.SubGroupID, cascadeDelete: false)
                .Index(t => t.SubGroupID);
            
            CreateTable(
                "dbo.MedicalSubGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainGroupId = c.Int(nullable: false),
                        SubGroupEname = c.String(),
                        SubgroupAName = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalMainGroups", t => t.MainGroupId, cascadeDelete: false)
                .Index(t => t.MainGroupId);
            
            CreateTable(
                "dbo.MedicalMainGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainGroupEnglishName = c.String(),
                        MainGroupArabicName = c.String(),
                        MainGroupCode = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApproveMedicineDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApproveMedicineId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ApprovedQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApproveMedicines", t => t.ApproveMedicineId, cascadeDelete: false)
                .ForeignKey("dbo.MedicineForReclaims", t => t.ServiceId, cascadeDelete: false)
                .Index(t => t.ApproveMedicineId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.ApproveMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsurId = c.Int(nullable: false),
                        ReqCenterId = c.Int(nullable: false),
                        RouchitaNo = c.Int(nullable: false),
                        ExcCenterId = c.Int(nullable: false),
                        ApproveDate = c.DateTime(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        pharmacistId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisId, cascadeDelete: false)
                .ForeignKey("dbo.Pharmacists", t => t.pharmacistId, cascadeDelete: false)
                .ForeignKey("dbo.Subscribers", t => t.InsurId, cascadeDelete: false)
                .Index(t => t.InsurId)
                .Index(t => t.DiagnosisId)
                .Index(t => t.pharmacistId);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiagnosisName = c.String(),
                        Activated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pharmacists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pharmacistName = c.String(),
                        Activated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineForReclaims",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Generic_name = c.String(),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InContract = c.Boolean(nullable: false),
                        Activated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApprovePictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApproveId = c.Int(nullable: false),
                        UploadId = c.Int(nullable: false),
                        ApproveNo = c.String(),
                        ScannedPicture = c.Binary(),
                        PhotoName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approves", t => t.ApproveId, cascadeDelete: false)
                .ForeignKey("dbo.Uploads", t => t.UploadId, cascadeDelete: false)
                .Index(t => t.ApproveId)
                .Index(t => t.UploadId);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsurId = c.Int(nullable: false),
                        ReqCenterId = c.Int(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        Uploaded = c.Boolean(),
                        Answered = c.Boolean(),
                        UnderProcess = c.Boolean(),
                        UploadNotes = c.String(),
                        ReplyNotes = c.String(),
                        UploadUser = c.String(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterInfoes", t => t.ReqCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.ReqCenterId)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.CenterInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CenterName = c.String(),
                        LocalityId = c.Int(nullable: false),
                        CenterLevel = c.Int(nullable: false),
                        HasContract = c.Boolean(nullable: false),
                        CenterTypeId = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApprovePrints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApproveId = c.Int(nullable: false),
                        ApproveNo = c.String(),
                        PrintDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approves", t => t.ApproveId, cascadeDelete: false)
                .Index(t => t.ApproveId);
            
            CreateTable(
                "dbo.ATCclassifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ATC_classification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanySettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        LogoPath1 = c.Binary(),
                        LogoPath2 = c.Binary(),
                        ManagerName = c.String(),
                        WebSite = c.String(),
                        Management = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigName = c.String(),
                        ConfigValue = c.String(),
                        Descriptions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Generics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenericName = c.String(),
                        Unit_Id = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id, cascadeDelete: false)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Unit_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysForms", t => t.FormId, cascadeDelete: false)
                .ForeignKey("dbo.UserGroups", t => t.GroupId, cascadeDelete: false)
                .Index(t => t.FormId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.SysForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemsId = c.Int(nullable: false),
                        FormName = c.String(),
                        EnglishFormName = c.String(),
                        ArabicFormName = c.String(),
                        FormType = c.String(),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Systems", t => t.SystemsId, cascadeDelete: false)
                .Index(t => t.SystemsId);
            
            CreateTable(
                "dbo.Systems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemName = c.String(),
                        ServerIP = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MACAddress = c.String(),
                        Date = c.DateTime(nullable: false),
                        logStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalServicesTemps",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SubGroupID = c.Int(nullable: false),
                        ServiceEName = c.String(),
                        ServiceAName = c.String(),
                        ServiceEmPrice = c.Decimal(precision: 18, scale: 2),
                        ServicePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceFrequency = c.Int(),
                        Duration = c.Int(),
                        ListType = c.Int(nullable: false),
                        NeedApproveMent = c.Boolean(),
                        InContract = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(),
                        Sessions = c.Int(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineListPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListId = c.Int(nullable: false),
                        GenericId = c.Int(nullable: false),
                        GenericPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicines", t => t.GenericId, cascadeDelete: false)
                .ForeignKey("dbo.MedicineLists", t => t.ListId, cascadeDelete: false)
                .Index(t => t.ListId)
                .Index(t => t.GenericId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ATC_code = c.String(),
                        ATCId = c.Int(nullable: false),
                        GenericId = c.Int(),
                        Generic_name = c.String(),
                        Unit_Id = c.Int(nullable: false),
                        PL = c.Int(nullable: false),
                        HICKS_DC = c.String(),
                        NOTE = c.String(),
                        DDD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        U = c.String(),
                        Adm_R = c.String(),
                        Regestration = c.String(),
                        TermsOfUse = c.String(),
                        UserId = c.Int(nullable: false),
                        UpdateUser = c.Int(nullable: false),
                        DeleteUser = c.Int(nullable: false),
                        Activated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ATCclassifications", t => t.ATCId, cascadeDelete: false)
                .ForeignKey("dbo.Units", t => t.Unit_Id, cascadeDelete: false)
                .Index(t => t.ATCId)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.MedicineLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineTemps",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ATC_code = c.String(),
                        ATCId = c.Int(nullable: false),
                        ListId = c.Int(nullable: false),
                        GenericId = c.Int(nullable: false),
                        Generic_name = c.String(),
                        Unit_Id = c.Int(nullable: false),
                        PL = c.Int(nullable: false),
                        HICKS_DC = c.String(),
                        NOTE = c.String(),
                        DDD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        U = c.String(),
                        Adm_R = c.String(),
                        Regestration = c.String(),
                        TermsOfUse = c.String(),
                        NeedApprovement = c.Boolean(nullable: false),
                        ApproveByCall = c.Boolean(nullable: false),
                        EditeMode = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UpdateUser = c.Int(nullable: false),
                        DeleteUser = c.Int(nullable: false),
                        Activated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReclaimBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReclaimId = c.Int(nullable: false),
                        ServiceProviderId = c.Int(nullable: false),
                        BillNo = c.String(),
                        BillDate = c.DateTime(nullable: false),
                        BillTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterInfoes", t => t.ServiceProviderId, cascadeDelete: false)
                .ForeignKey("dbo.Reclaims", t => t.ReclaimId, cascadeDelete: false)
                .Index(t => t.ReclaimId)
                .Index(t => t.ServiceProviderId);
            
            CreateTable(
                "dbo.Reclaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReclaimNo = c.String(),
                        ReclaimDate = c.DateTime(nullable: false),
                        SubscriberId = c.Int(nullable: false),
                        BillsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReclaimTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MedicalTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MedicineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        ReclaimStatus = c.Int(nullable: false),
                        RefMedicineExcCenterId = c.Int(),
                        RefMedicineReqCenterId = c.Int(),
                        RefMedicalExcCenterId = c.Int(),
                        RefMedicalReqCenterId = c.Int(),
                        ReclaimMedicalResonId = c.Int(nullable: false),
                        ReclaimMedicineResonId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReclaimMedicalReasonsLists", t => t.ReclaimMedicalResonId, cascadeDelete: false)
                .ForeignKey("dbo.ReclaimMedicineReasonsLists", t => t.ReclaimMedicineResonId, cascadeDelete: false)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberId, cascadeDelete: false)
                .Index(t => t.SubscriberId)
                .Index(t => t.ReclaimMedicalResonId)
                .Index(t => t.ReclaimMedicineResonId);
            
            CreateTable(
                "dbo.ReclaimMedicalReasonsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicalReason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReclaimMedicineReasonsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicineReason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReclaimMedicals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReclaimId = c.Int(nullable: false),
                        MedicalId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ReclaimCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReclaimTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Percentages = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalServices", t => t.MedicalId, cascadeDelete: false)
                .ForeignKey("dbo.Reclaims", t => t.ReclaimId, cascadeDelete: false)
                .Index(t => t.ReclaimId)
                .Index(t => t.MedicalId);
            
            CreateTable(
                "dbo.ReclaimMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReclaimId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ReclaimCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReclaimTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Percentages = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicineForReclaims", t => t.MedicineId, cascadeDelete: false)
                .ForeignKey("dbo.Reclaims", t => t.ReclaimId, cascadeDelete: false)
                .Index(t => t.ReclaimId)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TradeName = c.String(),
                        GenericId = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Generics", t => t.GenericId, cascadeDelete: false)
                .Index(t => t.GenericId);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysForms", t => t.FormId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.FormId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPermissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPermissions", "FormId", "dbo.SysForms");
            DropForeignKey("dbo.Trades", "GenericId", "dbo.Generics");
            DropForeignKey("dbo.ReclaimMedicines", "ReclaimId", "dbo.Reclaims");
            DropForeignKey("dbo.ReclaimMedicines", "MedicineId", "dbo.MedicineForReclaims");
            DropForeignKey("dbo.ReclaimMedicals", "ReclaimId", "dbo.Reclaims");
            DropForeignKey("dbo.ReclaimMedicals", "MedicalId", "dbo.MedicalServices");
            DropForeignKey("dbo.ReclaimBills", "ReclaimId", "dbo.Reclaims");
            DropForeignKey("dbo.Reclaims", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.Reclaims", "ReclaimMedicineResonId", "dbo.ReclaimMedicineReasonsLists");
            DropForeignKey("dbo.Reclaims", "ReclaimMedicalResonId", "dbo.ReclaimMedicalReasonsLists");
            DropForeignKey("dbo.ReclaimBills", "ServiceProviderId", "dbo.CenterInfoes");
            DropForeignKey("dbo.MedicineListPrices", "ListId", "dbo.MedicineLists");
            DropForeignKey("dbo.MedicineListPrices", "GenericId", "dbo.Medicines");
            DropForeignKey("dbo.Medicines", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Medicines", "ATCId", "dbo.ATCclassifications");
            DropForeignKey("dbo.GroupPermissions", "GroupId", "dbo.UserGroups");
            DropForeignKey("dbo.GroupPermissions", "FormId", "dbo.SysForms");
            DropForeignKey("dbo.SysForms", "SystemsId", "dbo.Systems");
            DropForeignKey("dbo.Generics", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.ApprovePrints", "ApproveId", "dbo.Approves");
            DropForeignKey("dbo.ApprovePictures", "UploadId", "dbo.Uploads");
            DropForeignKey("dbo.Uploads", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Uploads", "ReqCenterId", "dbo.CenterInfoes");
            DropForeignKey("dbo.ApprovePictures", "ApproveId", "dbo.Approves");
            DropForeignKey("dbo.ApproveMedicineDetails", "ServiceId", "dbo.MedicineForReclaims");
            DropForeignKey("dbo.ApproveMedicineDetails", "ApproveMedicineId", "dbo.ApproveMedicines");
            DropForeignKey("dbo.ApproveMedicines", "InsurId", "dbo.Subscribers");
            DropForeignKey("dbo.ApproveMedicines", "pharmacistId", "dbo.Pharmacists");
            DropForeignKey("dbo.ApproveMedicines", "DiagnosisId", "dbo.Diagnosis");
            DropForeignKey("dbo.ApproveDetails", "ServiceId", "dbo.MedicalServices");
            DropForeignKey("dbo.MedicalServices", "SubGroupID", "dbo.MedicalSubGroups");
            DropForeignKey("dbo.MedicalSubGroups", "MainGroupId", "dbo.MedicalMainGroups");
            DropForeignKey("dbo.ApproveDetails", "ApproveId", "dbo.Approves");
            DropForeignKey("dbo.Approves", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "GroupId", "dbo.UserGroups");
            DropForeignKey("dbo.Approves", "InsurId", "dbo.Subscribers");
            DropForeignKey("dbo.Approves", "LocalityId", "dbo.Localities");
            DropIndex("dbo.UserPermissions", new[] { "UserId" });
            DropIndex("dbo.UserPermissions", new[] { "FormId" });
            DropIndex("dbo.Trades", new[] { "GenericId" });
            DropIndex("dbo.ReclaimMedicines", new[] { "MedicineId" });
            DropIndex("dbo.ReclaimMedicines", new[] { "ReclaimId" });
            DropIndex("dbo.ReclaimMedicals", new[] { "MedicalId" });
            DropIndex("dbo.ReclaimMedicals", new[] { "ReclaimId" });
            DropIndex("dbo.Reclaims", new[] { "ReclaimMedicineResonId" });
            DropIndex("dbo.Reclaims", new[] { "ReclaimMedicalResonId" });
            DropIndex("dbo.Reclaims", new[] { "SubscriberId" });
            DropIndex("dbo.ReclaimBills", new[] { "ServiceProviderId" });
            DropIndex("dbo.ReclaimBills", new[] { "ReclaimId" });
            DropIndex("dbo.Medicines", new[] { "Unit_Id" });
            DropIndex("dbo.Medicines", new[] { "ATCId" });
            DropIndex("dbo.MedicineListPrices", new[] { "GenericId" });
            DropIndex("dbo.MedicineListPrices", new[] { "ListId" });
            DropIndex("dbo.SysForms", new[] { "SystemsId" });
            DropIndex("dbo.GroupPermissions", new[] { "GroupId" });
            DropIndex("dbo.GroupPermissions", new[] { "FormId" });
            DropIndex("dbo.Generics", new[] { "Unit_Id" });
            DropIndex("dbo.ApprovePrints", new[] { "ApproveId" });
            DropIndex("dbo.Uploads", new[] { "Users_Id" });
            DropIndex("dbo.Uploads", new[] { "ReqCenterId" });
            DropIndex("dbo.ApprovePictures", new[] { "UploadId" });
            DropIndex("dbo.ApprovePictures", new[] { "ApproveId" });
            DropIndex("dbo.ApproveMedicines", new[] { "pharmacistId" });
            DropIndex("dbo.ApproveMedicines", new[] { "DiagnosisId" });
            DropIndex("dbo.ApproveMedicines", new[] { "InsurId" });
            DropIndex("dbo.ApproveMedicineDetails", new[] { "ServiceId" });
            DropIndex("dbo.ApproveMedicineDetails", new[] { "ApproveMedicineId" });
            DropIndex("dbo.MedicalSubGroups", new[] { "MainGroupId" });
            DropIndex("dbo.MedicalServices", new[] { "SubGroupID" });
            DropIndex("dbo.Users", new[] { "GroupId" });
            DropIndex("dbo.Approves", new[] { "LocalityId" });
            DropIndex("dbo.Approves", new[] { "UserId" });
            DropIndex("dbo.Approves", new[] { "InsurId" });
            DropIndex("dbo.ApproveDetails", new[] { "ServiceId" });
            DropIndex("dbo.ApproveDetails", new[] { "ApproveId" });
            DropTable("dbo.UserPermissions");
            DropTable("dbo.Trades");
            DropTable("dbo.ReclaimMedicines");
            DropTable("dbo.ReclaimMedicals");
            DropTable("dbo.ReclaimMedicineReasonsLists");
            DropTable("dbo.ReclaimMedicalReasonsLists");
            DropTable("dbo.Reclaims");
            DropTable("dbo.ReclaimBills");
            DropTable("dbo.MedicineTemps");
            DropTable("dbo.MedicineLists");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicineListPrices");
            DropTable("dbo.MedicineLevels");
            DropTable("dbo.MedicalServicesTemps");
            DropTable("dbo.Logs");
            DropTable("dbo.Systems");
            DropTable("dbo.SysForms");
            DropTable("dbo.GroupPermissions");
            DropTable("dbo.Units");
            DropTable("dbo.Generics");
            DropTable("dbo.Configurations");
            DropTable("dbo.CompanySettings");
            DropTable("dbo.ATCclassifications");
            DropTable("dbo.ApprovePrints");
            DropTable("dbo.CenterInfoes");
            DropTable("dbo.Uploads");
            DropTable("dbo.ApprovePictures");
            DropTable("dbo.MedicineForReclaims");
            DropTable("dbo.Pharmacists");
            DropTable("dbo.Diagnosis");
            DropTable("dbo.ApproveMedicines");
            DropTable("dbo.ApproveMedicineDetails");
            DropTable("dbo.MedicalMainGroups");
            DropTable("dbo.MedicalSubGroups");
            DropTable("dbo.MedicalServices");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Users");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Localities");
            DropTable("dbo.Approves");
            DropTable("dbo.ApproveDetails");
        }
    }
}
