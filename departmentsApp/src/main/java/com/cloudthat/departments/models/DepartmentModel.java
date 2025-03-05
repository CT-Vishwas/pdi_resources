package com.cloudthat.departments.models;


public class DepartmentModel {

    private Integer id;
    private String departmentName;
    private String location;

    public DepartmentModel() {
    }

    public DepartmentModel(Integer id, String departmentName, String location) {
        this.id = id;
        this.departmentName = departmentName;
        this.location = location;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getDepartmentName() {
        return departmentName;
    }

    public void setDepartmentName(String departmentName) {
        this.departmentName = departmentName;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }
}
