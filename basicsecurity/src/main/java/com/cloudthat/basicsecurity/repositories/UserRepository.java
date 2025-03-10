package com.cloudthat.basicsecurity.repositories;

import com.cloudthat.basicsecurity.entities.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {
   User findByEmail(String email);
}
