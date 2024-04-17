using Rabbit.Models.Entities;
using Rabbit.Repository.Interfaces;
using Rabbit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Services.Services
{
    public class RabbitMensagemService : IRabbitMensagemService
    {
        private readonly IRabbitMensagemRepository _repo;
        public RabbitMensagemService(IRabbitMensagemRepository repo)
        {
            _repo = repo;   
        }
        public void SendMnesagem(RabbitMensagem mensagem)
        {
            _repo.SendMnesagem(mensagem);
        }
    }
}
