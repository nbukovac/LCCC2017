﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindIt.Models;
using FindIt.ViewModels;

namespace FindIt.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Games, Guid>
    {
        Task<NewGameViewModel> CreateNewGame();
    }
}
