-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE IF NOT EXISTS vaultKeeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'When Last Updated',
  creatorId VARCHAR(255) NOT NULL,
  vaultId INT NOT NULL,
  keepId INT NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  Foreign Key (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

-- DROP TABLE vaultKeeps;

SELECT
    vk.*
    FROM vaultKeeps vk
    WHERE vk.vaultId = 20;

SELECT keepId FROM vaultKeeps WHERE `vaultId` = 7;