using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoutePlanningCES.SharedConstants;
using Type = Models.Type;

namespace RoutePlanningCES.Controllers
{
    public class EdgesController : ApiController
    {
        private class EdgeRequest
        {
            public EdgeRequest(int width, int height, int length, float weight, List<string> parcelType)
            {
                this.Dimensions = new Dimension(width, height, length);
                this.weight = weight;
                this.ParcelType = parcelType;
            }
            public EdgeRequest() { }
            public Dimension Dimensions { get; set; }
            public float weight { get; set; }
            public List<string> ParcelType { get; set; }
        }

        private class EdgeResponse
        {
            public EdgeResponse(string origin, string destination, int time, float price)
            {
                this.Origin = origin;
                this.Destination = destination;
                this.Time = time;
                this.Price = price;
            }
            public EdgeResponse() { }
            public string Origin { get; set; }
            public string Destination { get; set; }
            public int Time { get; set; }
            public float Price { get; set; }
        }

        private TLContext db = new TLContext();
        private List<string> allowedTypes = new List<string>()
        {
            Constants.RecommendedType,
            Constants.CautiousParcelsType,
            Constants.RefrigeratedGoodsType,
            Constants.LiveAnimalsType,
            Constants.Empty
        };

        [Route("api/GetRoutes")]
        public IHttpActionResult GetEdges()
        {
            string jsonBody;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                jsonBody = reader.ReadToEnd();
            }

            EdgeRequest request;
            try
            {
                request = JsonConvert.DeserializeObject<EdgeRequest>(jsonBody);
            }
            catch (Exception e) 
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            IList<Edge> edges = db.GetAllEdges();
            
            List<EdgeResponse> response = CreateOurResponse(edges, request.ParcelType, request.weight);
            if (!response.Any())
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(response);
        }

        private List<EdgeResponse> CreateOurResponse(IList<Edge> edges, List<string> types, float weight)
        {
            List<EdgeResponse> result = new List<EdgeResponse>();
            foreach (Edge edge in edges)
            {
                //TODO do this in sql!
                if (weight > 40)
                    continue;
                if (!AcceptedType(types))
                    continue;

                var basePrice = edge.Price;
                foreach (var type in types)
                {
                    if (type.Equals(Constants.RecommendedType))
                        basePrice += Constants.RecommendedAddOn;
                    if (type.Equals(Constants.LiveAnimalsType))
                        basePrice += edge.Price * Constants.LiveAnmialsAddOn;
                    if (type.Equals(Constants.CautiousParcelsType))
                        basePrice += edge.Price * Constants.CautiousParcelsAddOn;
                    if (type.Equals(Constants.RefrigeratedGoodsType))
                        basePrice += edge.Price * Constants.RefrigeratedGoodsAddOn;
                }

                result.Add(new EdgeResponse(edge.SourceCity.Name, edge.DestinationCity.Name, (int)edge.Duration, basePrice));
            }
            return result;
        }

        private bool AcceptedType(List<string> strTypes)
        {
            bool acceptedType = true;
            foreach (var strType in strTypes)
            {
                if (!allowedTypes.Contains(strType))
                {
                    acceptedType = false;
                    break;
                }
            }

            return acceptedType;
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EdgeExists(int id)
        {
            return db.Edge.Count(e => e.ID == id) > 0;
        }

        public static IList<Edge> GetRoutesAnotherAPI(string url, Parcel parcel)
        {
            IList<Edge> edges = new List<Edge>();
            Dimension dim = parcel.Dimensions;
            List<string> types = new List<string>();
            foreach (var type in parcel.Type)
            {
                types.Add(type.Name);
            }
            EdgeRequest requestBody = new EdgeRequest((int)dim.Width, (int)dim.Height, (int)dim.Length, 39, types);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<System.Security.Cryptography.Xml.DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                
                }

                EdgeResponse edgeResponse = JsonConvert.DeserializeObject<EdgeResponse>("");
            }

            return edges;
        }
    }
}