using Rabbit.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Repository.Interfaces
{
    public interface IRabbitMensagemRepository
    {
        void SendMnesagem(RabbitMensagem mensagem);

    }
}
