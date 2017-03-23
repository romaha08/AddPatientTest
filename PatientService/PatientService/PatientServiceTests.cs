namespace PatientService
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PatientService.PatientServiceClient;

    [TestClass]
    public class PatientServiceTests : TestBase
    {
        [TestMethod]
        public void Add_Patient_Service_Valid_Info_Test()
        {
            var patient = this.GetPatientInfo(1, 1, true);

            this.PixServiceClient.AddPatient(this.Guid.ToString(), TestUtils.TestUtils.idLpu, patient);

            // Get from DB or something else
            var patinetAdded = new PatientDto();

            // Check
            Assert.AreEqual(patinetAdded, patient);
        }

        [TestMethod]
        public void Add_Patient_Service_InValid_Info_Patient_Test_Failed()
        {
            var patient = this.GetPatientInfo(0, 0, true);

            try
            {
                this.PixServiceClient.AddPatient(this.Guid.ToString(), TestUtils.TestUtils.idLpu, patient);
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nTest Completed");
            }
        }

        [TestMethod]
        public void Add_Patient_Service_InValid_Info_Guid_Test_Failed()
        {
            var patient = this.GetPatientInfo(1, 1, true);

            try
            {
                this.PixServiceClient.AddPatient("8CDE415D-FAB7-4809-AA00-8CDD70B1Р460", TestUtils.TestUtils.idLpu, patient);
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nTest Completed");
            }
        }

        [TestMethod]
        public void Add_Patient_Service_InValid_Info_Lpu_Test_Failed()
        {
            var patient = this.GetPatientInfo(1, 1, true);

            try
            {
                this.PixServiceClient.AddPatient(this.Guid.ToString(), "0", patient);
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nTest Completed");
            }
        }

        [TestMethod]
        public void Add_Patient_Service_Dublicate_Patient_Test_Failed()
        {
            var patient = this.GetPatientInfo(1, 1, true);

            this.PixServiceClient.AddPatient(this.Guid.ToString(), TestUtils.TestUtils.idLpu, patient);
            try
            {
                this.PixServiceClient.AddPatient(this.Guid.ToString(), TestUtils.TestUtils.idLpu, patient);
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nTest Completed");
            }
        }
    }
}
