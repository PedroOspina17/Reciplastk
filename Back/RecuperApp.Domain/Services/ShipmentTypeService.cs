using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class ShipmentTypeService
    {
        private readonly ReciplastkContext db;
        public ShipmentTypeService(ReciplastkContext db)
        {
            this.db = db;
        }
        public HttpResponseModel GetAll()
        {
            var shipmentType = db.ShipmentTypes.Where(x => x.IsActive == true).ToList();
            var response = new HttpResponseModel
            {
                WasSuccessful = true,
                Data = shipmentType
            };
            return response;
        }
        public HttpResponseModel GetById(int shipmenttypeid)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmenttypeid);
            if (shipmentType != null)
            {
                response.WasSuccessful = true;
                response.Data = shipmentType;
                response.StatusMessage = "El tipo de cargamento se encontro correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cargamento con el id indicado";
            }
            return response;
        }
        private ShipmentType GetByid(int shipmenttypeid)
        {
            var shipmentType = db.ShipmentTypes.Where(x => x.ShipmentTypeId == shipmenttypeid && x.IsActive == true).FirstOrDefault();
            return shipmentType;
        }

        private ShipmentType GetByName(string shipmenttypeName)
        {
            var shipmentType = db.ShipmentTypes.Where(x => x.Name == shipmenttypeName && x.IsActive == true).FirstOrDefault();
            return shipmentType;
        }
        public HttpResponseModel Create(ShipmentTypeRequest shipmentTypeViewModel)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByName(shipmentTypeViewModel.name);
            if (shipmentType != null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "Ya existe un tipo con el mismo nombre.";

            }
            else
            {

                var newShipmentType = new ShipmentType
                {
                    Name = shipmentTypeViewModel.name,
                    Description = shipmentTypeViewModel.description,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                db.ShipmentTypes.Add(newShipmentType);
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de cargamento se creo exitosamente";
            }
            return response;
        }
        public HttpResponseModel Update(ShipmentTypeRequest shipmentTypeViewModel)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmentTypeViewModel.shipmenttypeid);
            if (shipmentType != null)
            {
                shipmentType.ShipmentTypeId = shipmentTypeViewModel.shipmenttypeid;
                shipmentType.Name = shipmentTypeViewModel.name;
                shipmentType.Description = shipmentTypeViewModel.description;
                shipmentType.UpdatedDate = DateTime.Now;
                shipmentType.IsActive = true;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo de cargamento se edito exitosamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo de cargamento con el id indicado";
            }
            return response;
        }
        public HttpResponseModel Delete(int shipmentTypeId)
        {
            var response = new HttpResponseModel();
            var shipmentType = GetByid(shipmentTypeId);
            if (shipmentType != null)
            {
                shipmentType.IsActive = false;
                db.SaveChanges();
                response.WasSuccessful = true;
                response.StatusMessage = "El tipo cargamento se elimino correctamente";
            }
            else
            {
                response.WasSuccessful = false;
                response.StatusMessage = "No se encontro ningun tipo cargamento con el id indicado";

            }
            return response;
        }
    }
}
