namespace PatientService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PatientService.PatientServiceClient;
    using PatientService.TestUtils;

    public class TestBase
    {
        public PixServiceClient PixServiceClient;

        public Guid Guid;

        public TestBase()
        {
            this.PixServiceClient = new PixServiceClient();
            this.Guid = new Guid("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C");
        }

        public PatientDto GetPatientInfo(int countOfAddresses, int countOfContacts, bool isVip)
        {
            var patient = new PatientDto
            {
                Addresses = TestUtils.TestUtils.GetPatientAddresses(countOfAddresses),
                BirthDate = new DateTime(1895, 06, 21),
                BirthPlace = TestUtils.TestUtils.GetBirthPlaceOfPatient(),
                DeathTime = null,
                ContactPerson = TestUtils.TestUtils.GetContactPersonOfPatient(),
                Contacts = TestUtils.TestUtils.GetContacts(countOfContacts),
                FamilyName = "FamilyName_" + Extensions.CreateRandomString(3),
                MiddleName = "MiddleName_" + Extensions.CreateRandomString(3),
                GivenName = "GivenName_" + Extensions.CreateRandomString(3),
                IdBloodType = TestUtils.TestUtils.IdBloodType,
                IdGlobal = "123123123",
                IdLivingAreaType = TestUtils.TestUtils.IdLivingAreaType,
                IdPatientMIS = "2134213123",
                IsVip = isVip,
                Job = TestUtils.TestUtils.GetJobOfPatient(),
                Sex = TestUtils.TestUtils.Sex,
                SocialStatus = "Status1",
                SocialGroup = null,
                Privilege = TestUtils.TestUtils.GetPrivilegeOfPatient(),
                Documents = TestUtils.TestUtils.GetDocuments(1)
            };

            return patient;
        }

        [TestInitialize]
        public void Start()
        {
            // Here will be something like this: 
            //this.PixServiceClient.ClientCredentials.UserName.UserName = "TestUserAdmin";
            //this.PixServiceClient.ClientCredentials.UserName.Password = "TestUserAdminPassword";
        }

        /// <summary>
        /// The stop.
        /// </summary>
        [TestCleanup]
        public void Stop()
        {
            // Here will be methods like this.PixServiceClient.RemovePatient()
        }
    }
}
