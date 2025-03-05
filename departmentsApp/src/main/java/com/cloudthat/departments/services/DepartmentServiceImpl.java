package com.cloudthat.departments.services;

import com.cloudthat.departments.entities.Department;
import com.cloudthat.departments.models.DepartmentModel;
import com.cloudthat.departments.repositories.DepartmentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Objects;

@Service
public class DepartmentServiceImpl implements DepartmentService{

    @Autowired
    DepartmentRepository departmentRepository;

    @Override
    public DepartmentModel createNewDepartment(DepartmentModel departmentModel) {
        return departmentToDepartmentModel(departmentRepository.save(departmentModelToDepartment(departmentModel)));
    }

    @Override
    public DepartmentModel getDepartment(Integer id) {
        Department department = departmentRepository.findById(id).get();
        return departmentToDepartmentModel(department);
    }

    @Override
    public List<DepartmentModel> getAllDepartments() {
        return departmentRepository
                .findAll()
                .stream()
                .map(this::departmentToDepartmentModel)
                .toList();
    }

    @Override
    public DepartmentModel updateDepartment(Integer id, DepartmentModel departmentModel) {
        Department departmentDb = departmentRepository.findById(id).get();
        if(Objects.nonNull(departmentModel.getLocation()) && "".equalsIgnoreCase(departmentModel.getLocation())){
            departmentDb.setLocation(departmentModel.getLocation());
        }

        return departmentToDepartmentModel(departmentRepository.save(departmentDb));
    }

    @Override
    public void deleteDepartment(Integer id) {
        Department departmentDb = departmentRepository.findById(id).get();
        departmentRepository.delete(departmentDb);
    }

    protected Department departmentModelToDepartment(DepartmentModel departmentModel){
        Department department = new Department();
        department.setId(departmentModel.getId());
        department.setDepartmentName(departmentModel.getDepartmentName());
        department.setLocation(departmentModel.getLocation());

        return department;
    }

    protected DepartmentModel departmentToDepartmentModel(Department department){
        DepartmentModel departmentModel = new DepartmentModel();
        departmentModel.setId(department.getId());
        departmentModel.setDepartmentName(department.getDepartmentName());
        departmentModel.setLocation(department.getLocation());

        return departmentModel;
    }
}
