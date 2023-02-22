﻿using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<IList<CatalogBrand>> GetAllAsync();
    }
}
