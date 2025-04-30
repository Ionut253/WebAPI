﻿namespace WebApi.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ClassLibrary.IRepository;
    using Data;
    using Domain;
    using Models;

    /// <summary>
    /// Repository class for managing department-related database operations.
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context instance.</param>
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            // Retrieve all departments from the database.
            List<DepartmentEntity> departmentEntities = await this.dbContext.Departments.ToListAsync();

            // Convert the list of DepartmentEntity to a list of Department models.
            List<Department> departments = departmentEntities
                .Select(departmentEntity => new Department
                {
                    Id = departmentEntity.Id,
                    Name = departmentEntity.Name
                })
                .ToList();

            return departments;
        }

        /// <inheritdoc/>
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            // Retrieve a department by its ID from the database.
            var departmentEntity = await this.dbContext.Departments.FindAsync(id);

            if (departmentEntity == null)
            {
                throw new Exception($"Department with ID {id} not found.");
            }

            // Return a new Department object (mapping from Entity to Domain model).
            return new Department
            {
                Id = departmentEntity.Id,
                Name = departmentEntity.Name
            };
        }

        /// <inheritdoc/>
        public async Task AddDepartmentAsync(Department department)
        {
            // Map the Department model to the DepartmentEntity.
            var departmentEntity = new DepartmentEntity
            {
                Name = department.Name
            };

            // Add the department to the database.
            this.dbContext.Departments.Add(departmentEntity);
            await this.dbContext.SaveChangesAsync();

            // Set the department's Id after it's saved.
            department.Id = departmentEntity.Id;
        }

        /// <inheritdoc/>
        public async Task DeleteDepartmentAsync(int id)
        {
            // Find the department by its ID.
            var departmentEntity = await this.dbContext.Departments.FindAsync(id);

            if (departmentEntity == null)
            {
                throw new Exception($"Department with ID {id} not found.");
            }

            // Remove the department from the database.
            this.dbContext.Departments.Remove(departmentEntity);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
