package com.cloudthat.addressbook.utilities;

import com.cloudthat.addressbook.entities.Email;
import com.cloudthat.addressbook.models.EmailModel;

import java.util.List;
import java.util.stream.Collectors;

public abstract class GenericConverter<E, M> {

    public abstract M convertToModel(E entity);
    public abstract E convertToEntity(M Model);

    public List<M> convertToModelList(List<E> entities){
        if(entities == null){
            return null;
        }
        return entities.stream()
                .map(this::convertToModel)
                .collect(Collectors.toList());
    }

    public List<E> convertToEntityList(List<M> models){
        if(models == null){
            return null;
        }
        return models.stream()
                .map(this::convertToEntity)
                .collect(Collectors.toList());
    }

}
