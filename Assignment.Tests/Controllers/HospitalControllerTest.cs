using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Controllers;
using System.Web.Mvc;
using Moq;
using Assignment.Models;
using System.Linq;

namespace Assignment.Tests.Controllers

{

    [TestClass]

    public class HospitalControllerTest

    {
        HospitalsController controller;
        Mock<IHospitalRepository> mock;
        List<Hospital> hospitals;
        
        [TestInitialize]

        public void TestInitialize()

        {
            
            mock = new Mock<IHospitalRepository>();
            hospitals = new List<Hospital>

            {

                new Hospital { HospitalId = 1, HospitalName = "RVH", HospitalAddress = "1georgian dr", PhoneNumber = 9895921 },
                new Hospital { HospitalId = 2, HospitalName = "RVH2", HospitalAddress = "2georgian dr", PhoneNumber = 9895921 },
                new Hospital { HospitalId = 3, HospitalName = "RVH3", HospitalAddress = "3georgian dr", PhoneNumber = 9895921 }
            };
            
           
            mock.Setup(m => m.Hospitals).Returns(hospitals.AsQueryable());
            
            controller = new HospitalsController(mock.Object);

        }
        
        [TestMethod]

        public void IndexViewLoads()

        {
            
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
                    }
        [TestMethod]

        public void IndexReturnsHospitals()

        {
                
            var actual = (List<Hospital>)controller.Index().Model;

            CollectionAssert.AreEqual(hospitals, actual);

        }
        
        [TestMethod]

        public void DetailsValidHospital()

        {
            var actual = (Hospital)controller.Details(1).Model;
            Assert.AreEqual(hospitals.ToList()[0], actual);

        }

        [TestMethod]

        public void DetailsInvalidHospitals()

        {
            
            var actual = (Hospital)controller.Details(11111222).Model;
            
            Assert.IsNull(actual);

        }
        
        [TestMethod]

        public void DetailsInvalidHospitalId()

        {
            int? id = null;
            var actual = controller.Details(id);
            Assert.AreEqual("error", actual.ViewName);

        }

        
        [TestMethod]

        public void EditHospitalValid()

        {
            var actual = (Hospital)controller.Edit(1).Model;
                
            Assert.AreEqual(hospitals.ToList()[0], actual);

        }
        
        [TestMethod]

        public void EditInvalidHospitalId()

        {
            
            int? id = null;
            
            var actual = (ViewResult)controller.Edit(id);
            
            Assert.AreEqual("Error", actual.ViewName);

        }



        [TestMethod]

        public void EditInvalidHoId()

        {
            ViewResult result = controller.Edit(-1122) as ViewResult;
            
            Assert.AreEqual("Error", result.ViewName);

        }

        
        [TestMethod]

        public void DeleteValidHospital()

        {

        
            var actual = (Hospital)controller.Delete(1).Model;
            
            Assert.AreEqual(hospitals.ToList()[0], actual);

        }
        
        [TestMethod]

        public void DeleteInvalidhospId()

        {
            
            int id = 11111112;
            
            ViewResult actual = (ViewResult)controller.Delete(id);
            
            Assert.AreEqual("Error", actual.ViewName);

        }



        [TestMethod]

        public void DeleteInvalidHoId()

        {
            
            int? id = null;

            ViewResult actual = controller.Delete(id);
            
            Assert.AreEqual("Error", actual.ViewName);

        }

        
        [TestMethod]

        public void CreateViewLoads()

        {
            ViewResult actual = (ViewResult)controller.Create();
            Assert.AreEqual("Create", actual.ViewName);

            Assert.IsNotNull(actual.ViewBag.HospitalId);
            

        }

        [TestMethod]

        public void CreateValidHospital()

        {


            Hospital hospital = new Hospital

            {

                HospitalId = 4,

                HospitalName = "RVH again",

                HospitalAddress = "23 georgian Dr",
                PhoneNumber = 12345

            };
            
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Create(hospital);
            

            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }
        [TestMethod]

        public void CreateInvalidHospital()

        {
           
            Hospital hospitaliz = new Hospital
            {
                HospitalId = 2,

                HospitalName = "RVH again",

                HospitalAddress = "23 georgian Dr",
                PhoneNumber = 12345

            };
            ViewResult actual = (ViewResult)controller.Create(hospitaliz);
            
            Assert.AreEqual("Create", actual.ViewName);

            Assert.IsNotNull(actual.ViewBag.HospitalId);

        }
        

        // POST: Edit

        [TestMethod]

        public void EditValidHospital()

        {

          
            Hospital hospital = hospitals.ToList()[0];

            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Edit(hospital);

            
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }



        [TestMethod]

        public void EditInvalidHospital()

        {
            
            Hospital hospital = new Hospital

            {

                HospitalId = 1342,

                HospitalName = "RVHbnvnm again",

                HospitalAddress = "23jhvgh georgian Dr",
                PhoneNumber = 1234545765

            };

            ViewResult actual = (ViewResult)controller.Edit(hospital);

            
            Assert.AreEqual("Edit", actual.ViewName);

            Assert.IsNotNull(actual.ViewBag.HospitalId);
            

        }
        

        [TestMethod]

        public void DeleteConfirmedValidHospital()

        {
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.DeleteConfirmed(1);
            
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }
        [TestMethod]

        public void DeleteConfirmedInvalidHospitalId()

        {
            int id = 1111112;
            
            ViewResult actual = (ViewResult)controller.DeleteConfirmed(id);
            
            Assert.AreEqual("Error", actual.ViewName);

        }
        

        [TestMethod]

        public void DeleteConfirmedInvalidhosoId()

        {         

            int? id = null;
   
            ViewResult actual = (ViewResult)controller.DeleteConfirmed(id);
    
            Assert.AreEqual("Error", actual.ViewName);

        }
        
    }

}