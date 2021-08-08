using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;


namespace fishcore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        public struct Location
        {
            public float X;
            public float Y;
        }

        public struct NodeData
        {
            public string Label;
        }

        public struct Element
        {
            
            public string Id { get; set; }
            public Dictionary<string, string> Position { get; set; }
            public string Type { get; set; }

            public Dictionary<string, string> Data { get; set; }
        }

        [HttpPost]
        public IActionResult Download([FromBody] object rawElements)
        {                        
            List<Element> elements = 
                JsonConvert.DeserializeObject<Dictionary<string, List<Element>>>(rawElements.ToString())["elements"];


            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(elements);

                       
            byte[] data = Encoding.ASCII.GetBytes(yaml);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = "export.yaml";
            return File(content, contentType, fileName);



            //return yaml;
        }

        public class Address
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
        }

        public class Receipt
        {
            public string receipt { get; set; }
            public DateTime date { get; set; }
            public Customer customer { get; set; }
            public Item[] items { get; set; }
            public Address bill_to { get; set; }
            public Address ship_to { get; set; }
            public string specialDelivery { get; set; }
        }

        public class Customer
        {
            public string given { get; set; }
            public string family { get; set; }
        }

        public class Item
        {
            public string part_no { get; set; }
            public string descrip { get; set; }
            public decimal price { get; set; }
            public int quantity { get; set; }
        }
    }
}
