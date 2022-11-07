-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'When Last Updated',
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  img VARCHAR(255) NOT NULL,
  isPrivate BOOLEAN NOT NULL DEFAULT false,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

-- DROP TABLE vaults;

SELECT
    vault.*,
    a.*
    FROM vaults vault
    JOIN accounts a ON a.id = vault.creatorId
    WHERE 
      vault.creatorId = "633cb69e37340e48a68947c1" AND
      vault.isPrivate != true;

SELECT
    vault.*,
    a.*
    FROM vaults vault
    JOIN accounts a ON a.id = vault.creatorId
    WHERE 
      vault.creatorId = "633cb69e37340e48a68947c1";
