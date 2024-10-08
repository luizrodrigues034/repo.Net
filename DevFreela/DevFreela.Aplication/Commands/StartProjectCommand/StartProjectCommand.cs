﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.StartProjectCommand
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public StartProjectCommand(int id) {
            Id = id;
        }
        public int Id { get; set; }
    }
}
