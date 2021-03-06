﻿using System;
using ADarkBlazor.Exceptions;
using ADarkBlazor.Services.Domain.Enums;
using ADarkBlazor.Services.Interfaces;

namespace ADarkBlazor.Services.Resources
{
    public abstract class Resource : IResource
    {
        private readonly IResourceService _resourceService;
        public bool IsVisible { get; set; }
        public EResourceType ResourceType { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; } = 0;

        public event Action OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();

        public virtual void Add(double amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

            Amount += amount;
            NotifyStateChanged();
        }

        public virtual void Subtract(double amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (Amount <= 0) throw new ResourceException();

            Amount -= amount;
            NotifyStateChanged();
        }

        public Resource(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public virtual void Enable()
        {
            IsVisible = true;
            NotifyStateChanged();
        }
    }
}