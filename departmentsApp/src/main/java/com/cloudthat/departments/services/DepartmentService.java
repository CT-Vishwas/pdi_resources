package com.cloudthat.departments.services;

import com.cloudthat.departments.entities.Department;
import com.cloudthat.departments.models.DepartmentModel;

import java.util.List;

public interface DepartmentService {
    DepartmentModel createNewDepartment(DepartmentModel departmentModel);

    DepartmentModel getDepartment(Integer id);

    List<DepartmentModel> getAllDepartments();

    DepartmentModel updateDepartment(Integer id, DepartmentModel departmentModel);

    void deleteDepartment(Integer id);
}
