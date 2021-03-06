﻿using System;
using System.Collections.Generic;
using ADarkBlazor.Services.Domain.Enums;
using ADarkBlazor.Services.Resources;

namespace ADarkBlazor.Services.Interfaces
{
    public interface IResourceService
    {
        event Action OnChange;
        IList<IResource> Resources { get; set; }
        void RegisterReources(IServiceProvider provider);

        void EnableResource(EResourceType type);
        void AddToResource(EResourceType type, double amount);
        void SubtractFromResource(EResourceType type, double amount);
    }
}