namespace PatientService.TestUtils
{
    using System;
    using System.Collections.Generic;
    using PatientService.PatientServiceClient;

    public static class TestUtils
    {
        private static readonly byte IdAddressType = Extensions.GetByteFromString("1.2.643.2.69.1.1.1.28");

        private static readonly byte IdContactType = Extensions.GetByteFromString("1.2.643.2.69.1.1.1.27");

        private static readonly byte IdRelationType = Extensions.GetByteFromString("1.2.643.2.69.1.1.1.65");

        private static readonly byte IdDisabilityType = Extensions.GetByteFromString("1.2.643.2.69.1.1.1.65");

        private static readonly byte IdPrivilegeType = Extensions.GetByteFromString("1.2.643.2.69.1.1.1.7");

        private static readonly byte IdDocumentType = Extensions.GetByteFromString("1.2.643.2.69.1.1.1.6");

        public static readonly byte IdBloodType = Extensions.GetByteFromString("1.2.3.4");

        public static readonly byte IdLivingAreaType = Extensions.GetByteFromString("11.22.33.44");

        public static readonly byte Sex = Extensions.GetByteFromString("1.2.643.5.1.13.2.1.1.156");
        
        private static readonly string IdPersonMis = "1243234324";

        public static string idLpu = Extensions.GetByteFromString("1.2.643.5.1.13.3.25.78.118").ToString();

        public static AddressDto[] GetPatientAddresses(int countOfAddresses)
        {
            var addresses = new AddressDto[countOfAddresses];

            var tempList = new List<AddressDto>();

            if (countOfAddresses > 0)
            {
                for (int i = 0; i < countOfAddresses; i++)
                {
                    var address = new AddressDto
                    {
                        Appartment = "Apartment_" + Extensions.CreateRandomInt(4),
                        Building = "Building_" + Extensions.CreateRandomInt(4),
                        City = "Saint-Petersburg",
                        GeoData = "1.2.4",
                        PostalCode = 199567,
                        IdAddressType = IdAddressType,
                        StringAddress = "Test Address"
                    };

                    tempList.Add(address);
                }

                addresses = tempList.ToArray();
            }

            return addresses;
        }

        public static BirthPlaceDto GetBirthPlaceOfPatient()
        {
            return new BirthPlaceDto
            {
                City = "Saint-Petersburg",
                Country = "Russia",
                Region = "St.-Petersburg"
            };
        }

        public static ContactPersonDto GetContactPersonOfPatient()
        {
            return new ContactPersonDto
            {
                ContactList = GetContacts(1),
                FamilyName = "Family_" + Extensions.CreateRandomString(4),
                GivenName = "TestGivenName",
                MiddleName = "TestMiddleName",
                IdPersonMis = IdPersonMis,
                IdRelationType = IdRelationType
            };
        }

        public static ContactDto[] GetContacts(int countOfContacts)
        {
            var contacts = new ContactDto[countOfContacts];

            var tempList = new List<ContactDto>();

            if (countOfContacts > 0)
            {
                for (int i = 0; i < countOfContacts; i++)
                {
                    var contact = new ContactDto
                    {
                        ContactValue = "TestContact",
                        IdContactType = IdContactType
                    };

                    tempList.Add(contact);
                }

                contacts = tempList.ToArray();
            }

            return contacts;
        }

        public static JobDto GetJobOfPatient()
        {
            return new JobDto
            {
                CompanyName = "Netrica",
                DateStart = DateTime.Now,
                DateEnd = null,
                OgrnCode = "11003045994445335",
                Position = "QA Test Lead",
                Sphere = "IT"
            };
        }

        public static PrivilegeDto GetPrivilegeOfPatient()
        {
            return new PrivilegeDto
            {
                DateStart = new DateTime(2016, 01, 01),
                DateEnd = DateTime.Now,
                Comment = "Test Commant",
                DisabilityDegree = "TestDisability",
                IsMain = true,
                MkbCode = "214312431234",
                IdDisabilityType = IdDisabilityType,
                IdPrivilegeType = IdPrivilegeType,
                PrivilegeDocument = GetDocumentOfPatient()
            };
        }

        public static DocumentDto GetDocumentOfPatient()
        {
            return new DocumentDto
                       {
                           DocN = "DocN",
                           DocS = "DocS",
                           DocumentName = "TestDocument" + Extensions.CreateRandomInt(4),
                           IdProvider = "123123",
                           ProviderName = "TestProvider",
                           RegionCode = "SP",
                           IssuedDate = null,
                           ExpiredDate = null,
                           StartDate = DateTime.Now,
                           IdDocumentType = IdDocumentType
            };
        }

        public static DocumentDto[] GetDocuments(int countOfDocuments)
        {
            var documents = new DocumentDto[countOfDocuments];

            var tempList = new List<DocumentDto>();

            if (countOfDocuments > 0)
            {
                for (int i = 0; i < countOfDocuments; i++)
                {
                    var doc = GetDocumentOfPatient();

                    tempList.Add(doc);
                }

                documents = tempList.ToArray();
            }

            return documents;
        }
    }
}
