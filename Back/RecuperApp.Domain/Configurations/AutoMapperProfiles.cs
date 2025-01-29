using AutoMapper;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Configurations
{
    //Un perfil(Profile) en AutoMapper describe cómo la herramienta debe mapear un objeto de un tipo a otro.
    public class AutoMapperProfiles : Profile
    {
        //Automapper es una biblioteca versátil y potente en C# diseñada para facilitar el mapeo objeto a objeto, haciendo que la transferencia de datos entre modelos de objetos complejos sea más sencilla y fácil de mantener. En este artículo, exploraremos cómo Automapper puede asignar propiedades de forma eficiente, aplanar modelos de objetos complejos y trabajar con varios tipos de objetos como objetos de dominio de usuario y objetos de transferencia de datos.
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<CustomerType, CustomerTypeRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<PaymentDetail, PaymentReceiptDetailRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Payment, PaymentReceiptRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<PayrollConfig, PayrollConfigRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<PriceType, PriceTypeRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Product, ProductsRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Shipment, ShipmentRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<ShipmentDetail, ShipmentDetailRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<ShipmentType, ShipmentTypeRequest>().ReverseMap(); // ToDo: Analyze the revese mapping.
            
            
            CreateMap<PayrollConfig, PayrollConfigViewModel>().ReverseMap(); // ToDo: Analyze the revese mapping.


            CreateMap<Role,RoleViewModel>().ReverseMap();
            CreateMap<Payment,PaymentViewModel>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Payment,RecivableViewModel>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Remaining,RemainigsViewModel>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Payment,PaymentViewModel>().ReverseMap(); // ToDo: Analyze the revese mapping.
            CreateMap<Role,RoleViewModel>().ReverseMap();
            
        }
    }
}
