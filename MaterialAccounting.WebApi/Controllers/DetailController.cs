using MaterialAccounting.Services;
using MaterialAccounting.Services.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MaterialAccounting.WebApi.Controllers
{
    public class DetailController : ApiController
    {
        private readonly IDetailService _detailService;

        public DetailController()
        {
            _detailService = Bootstrapper.Resolve<IDetailService>();
        }

        // GET: api/Detail
        public IEnumerable<Detail> Get()
        {
            return _detailService.GetAll();
        }

        // GET: api/Detail/5
        public Detail Get(long id)
        {
            return _detailService.GetById(id);
        }

        // POST: api/Detail
        public void Post([FromBody]Detail value)
        {
            _detailService.CreateNewDetail(value);
        }

        // PUT: api/Detail/5
        public void Put(long id, [FromBody]Detail value)
        {
            if (value.Id != id)
            {
                value.Id = id;
            }
            _detailService.UpdateDetail(value);
        }

        // DELETE: api/Detail/5
        public void Delete(long id)
        {
            _detailService.RemoveDetail(id);
        }
    }
}
