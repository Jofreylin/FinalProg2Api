using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(string id);
        bool Delete(string id);
        bool Add(Product Model); 
        bool Update(Product Model);
    }

    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;

        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();
            try
            {
                result = _productContext.Product.ToList();
            }
            catch (Exception e)
            {
                
            }
            return result;
        }

        public Product Get(string id)
        {
            var result = new Product();
            try
            {
                result = _productContext.Product.Single(x => x.ID == id);
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public bool Add(Product Model)
        {
            try
            {
                _productContext.Add(Model);
                _productContext.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(Product Model)
        {
            try
            {
                var originalModel = _productContext.Product.Single(x => x.ID == Model.ID);

                originalModel.ID = Model.ID;
                originalModel.Nombre = Model.Nombre;
                originalModel.Descripcion = Model.Descripcion;
                originalModel.Cantidad = Model.Cantidad;
                originalModel.Categoria = Model.Categoria;
                originalModel.Precio = Model.Precio;
                originalModel.IdReferencia = Model.IdReferencia;


                _productContext.Update(originalModel);
                _productContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                _productContext.Entry(new Product {ID = id }).State = EntityState.Deleted;
                _productContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
