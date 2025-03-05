package com.cloudthat.departments.controllers;

import com.cloudthat.departments.entities.Department;
import com.cloudthat.departments.models.ApiResponse;
import com.cloudthat.departments.models.DepartmentModel;
import com.cloudthat.departments.services.DepartmentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/departments")
public class DepartmentController {

    @Autowired
    DepartmentService departmentService;

    @PostMapping
    public ResponseEntity<ApiResponse> createDepartment(@RequestBody DepartmentModel departmentModel){
        DepartmentModel newDepartmentModel = departmentService.createNewDepartment(departmentModel);
        return new ResponseEntity<>(new ApiResponse("Department Created Successfully", true, newDepartmentModel), HttpStatus.CREATED);
    }


    @GetMapping("/{id}")
    public ResponseEntity<ApiResponse> getDepartment(@PathVariable Integer id){
        DepartmentModel newDepartmentModel = departmentService.getDepartment(id);
        return new ResponseEntity<>(new ApiResponse("Department fetched Successfully", true, newDepartmentModel), HttpStatus.OK);
    }

    @GetMapping
    public ResponseEntity<ApiResponse> getAllDepartments(){
        List<DepartmentModel> departmentModels = departmentService.getAllDepartments();
        return new ResponseEntity<>(new ApiResponse("Departments fetched Successfully", true, departmentModels), HttpStatus.OK);
    }

    @PutMapping("/{id}")
    public ResponseEntity<ApiResponse> updateDepartment(@PathVariable Integer id, @RequestBody DepartmentModel departmentModel){
        DepartmentModel updatedDepartmentModel = departmentService.updateDepartment(id, departmentModel);
        return new ResponseEntity<>(new ApiResponse("Department updated Successfully", true, updatedDepartmentModel), HttpStatus.OK);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<ApiResponse> deleteDepartment(@PathVariable Integer id){
        departmentService.deleteDepartment(id);
        return new ResponseEntity<>(new ApiResponse("Department deleted Successfully", true, null), HttpStatus.NO_CONTENT);
    }
}
