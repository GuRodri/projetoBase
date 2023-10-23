using HelperStockBeta.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Domain.Entities
{
    public sealed class Product : Entity
    {
        // public int Id { get; private set; } - REMOVIDO POR CONTA DA HERANÇA DO ENTITY
        public string Name { get; private set; }    
        public string Description { get; private set; } 
        public decimal Price { get; private set; }  
        public int Stock { get; private set; }  
        public string Image { get; private set; }    


        public Product(string name, string description, decimal price, int stock, string image) 
        {
           validationDoamin(name, description, price, stock, image);
            
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, 
                "Inavalid negative values for id.")
            validationDoamin(name, description, price, stock, image);

        }

        private void validationDoamin(string name, string description, decimal price, int stock, string image) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid short names, minimum 3 characteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, descripton is requered.");
            DomainExceptionValidation.When(description.Length < 5, 
                "Invalid short description, minimum 5 characteres");
            DomainExceptionValidation.When(price < 0,
                "Invalid negative values fro price.");
            DomainExceptionValidation.When(stock < 0, 
                "Invalid negative values for stock.");
            DomainExceptionValidation.When(image.Length > 250,
                "Invalid long URL, maximum 250 characteres");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            validationDoamin(name, description, price, stock, image);
            CategoryId = categoryId; 
        }
        //Relacionamento com categoria
        public int CategoryId { get;  set; }

        public Category Category { get;  set; }
    }
}
