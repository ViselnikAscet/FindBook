using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBookBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FindBookBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
         [HttpPut]
    public async Task<IActionResult> PutQuestion([FromBody] QuestionModel question)
    {
        // Veriyi almak için gelen question modeli kullanılır
        if (question == null)
        {
            return BadRequest("Geçersiz veri");
        }

        // Burada question verisini JSON olarak geri dönebilirsiniz
        string jsonQuestion = JsonConvert.SerializeObject(question);
        
        // Veriyi işleme, kaydetme veya başka işlemler yapma adımları burada gerçekleşir

        return Ok(jsonQuestion);
    }
        
    }
}