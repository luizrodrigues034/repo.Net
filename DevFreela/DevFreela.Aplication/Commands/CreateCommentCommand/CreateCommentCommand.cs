﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.CreateCommentCommand
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}
