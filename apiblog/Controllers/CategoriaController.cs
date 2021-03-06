﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiblog.Entities;
using apiblog.Interfaces;
using apiblog.Services;
using apiblog.Filters;
using apiblog.Models;

namespace apiblog.Controllers
{
    public class CategoriaController : ApiController
    {
        private IContext _context;

        public CategoriaController(IContext context)
        {
            _context = context;
        }

        [CustomAuthorize(RolesUser.Administrador, RolesUser.Editor)]
        public IEnumerable<Categoria> Get()
        {           
            CategoriaServices categoriaServices = new CategoriaServices(_context.GetContext());
            return categoriaServices.GetAll();
        }
        
        public Categoria Get(int id)
        {
            CategoriaServices categoriaServices = new CategoriaServices(_context.GetContext());
            return categoriaServices.Get(id);
        }

        [CustomAuthorize(RolesUser.Administrador, RolesUser.Editor)]
        public HttpResponseMessage Post([FromBody]Categoria categoria)
        {
            CategoriaServices categoriaServices = new CategoriaServices(_context.GetContext());
            categoriaServices.Create(categoria);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(int id, [FromBody]Categoria categoria)
        {
            CategoriaServices categoriaServices = new CategoriaServices(_context.GetContext());
            categoriaServices.Update(id, categoria);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            CategoriaServices categoriaServices = new CategoriaServices(_context.GetContext());
            categoriaServices.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }        

    }
}

