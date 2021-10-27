using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCore.Entity.Sizes;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaPos.DataAccess.SizesRepository
{
    public class SizesRepository : ISizesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SizesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveItemSize(SizesDto dto)
        {
            SizesDto entity = _dbContext.Sizes.Find(dto.SizesId);
            if (entity == null)
            {
                dto.SizeCreatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                dto.SizeUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                entity = _dbContext.Sizes.Add(dto).Entity;
            }
            else
            {
                entity.SizeName = dto.SizeName;
                entity.SizeStatus = dto.SizeStatus;
                entity.SizeUpdatedDate = $"{DateTime.Now:d/M/yyyy HH:mm:ss}";
                entity.Deleted = dto.Deleted;
                entity = _dbContext.Sizes.Update(entity).Entity;
            }

            _dbContext.SaveChanges();
            return entity != null;
        }

        public List<SizesDto> SizeList()
        {
            return new List<SizesDto>(_dbContext.Sizes.Where(dto => dto.Deleted != 1));
        }

        public List<SizesDto> GetActiveSizes()
        {
            return new List<SizesDto>(_dbContext.Sizes.Where(dto => dto.Deleted != 1 && dto.SizeStatus == 1));
        }

        public SizesDto GetById(int id)
        {
            return _dbContext.Sizes.Find(id);
        }
    }
}