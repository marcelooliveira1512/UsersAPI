# UsersAPI

Esta aplicação fornece uma API para gerenciamento de usuários, empresas, módulos, perfis (roles) e submódulos.

## Endpoints

### Autenticação (AUTH)

#### Autenticar o usuário
- Método: POST
- Rota: `/api/auth/login`
- Descrição: Autentica o usuário com suas credenciais.

#### Recuperar senha de acesso do usuário
- Método: POST
- Rota: `/api/auth/forgot-password`
- Descrição: Inicia o processo de recuperação de senha para o usuário.

#### Reiniciar senha de acesso do usuário
- Método: POST
- Rota: `/api/auth/reset-password`
- Descrição: Reinicia a senha de acesso do usuário após a recuperação.

### Empresas (COMPANYS)

#### Cadastrar uma nova empresa
- Método: POST
- Rota: `/api/companys`
- Descrição: Cadastra uma nova empresa.

#### Alterar os dados da empresa informada
- Método: PUT
- Rota: `/api/companys/{id}`
- Descrição: Altera os dados de uma empresa específica com base no ID.

#### Excluir a empresa informada
- Método: DELETE
- Rota: `/api/companys/{id}`
- Descrição: Exclui uma empresa com base no ID.

#### Lista todas as empresas cadastradas
- Método: GET
- Rota: `/api/companys/list`
- Descrição: Retorna a lista de todas as empresas cadastradas.

#### Retorna os dados da empresa informada
- Método: GET
- Rota: `/api/companys/get/{id}`
- Descrição: Retorna os dados de uma empresa específica com base no ID.

### Módulos (MODULES)

#### Cadastrar um novo módulo
- Método: POST
- Rota: `/api/modules`
- Descrição: Cadastra um novo módulo.

#### Alterar os dados do módulo informado
- Método: PUT
- Rota: `/api/modules/{id}`
- Descrição: Altera os dados de um módulo específico com base no ID.

#### Excluir o módulo informado
- Método: DELETE
- Rota: `/api/modules/{id}`
- Descrição: Exclui um módulo com base no ID.

#### Lista todos os módulos cadastrados
- Método: GET
- Rota: `/api/modules/list`
- Descrição: Retorna a lista de todos os módulos cadastrados.

#### Retorna os dados do módulo informado
- Método: GET
- Rota: `/api/modules/get/{id}`
- Descrição: Retorna os dados de um módulo específico com base no ID.

### Perfis (ROLES)

#### Cadastrar um novo perfil
- Método: POST
- Rota: `/api/roles`
- Descrição: Cadastra um novo perfil.

#### Alterar os dados do perfil informado
- Método: PUT
- Rota: `/api/roles/{id}`
- Descrição: Altera os dados de um perfil específico com base no ID.

#### Excluir o perfil informado
- Método: DELETE
- Rota: `/api/roles/{id}`
- Descrição: Exclui um perfil com base no ID.

#### Lista todos os perfis cadastrados
- Método: GET
- Rota: `/api/roles/list`
- Descrição: Retorna a lista de todos os perfis cadastrados.

#### Retorna os dados do perfil informado
- Método: GET
- Rota: `/api/roles/get/{id}`
- Descrição: Retorna os dados de um perfil específico com base no ID.

### Submódulos (SUBMODULES)

#### Cadastrar um novo submódulo
- Método: POST
- Rota: `/api/submodules`
- Descrição: Cadastra um novo submódulo.

#### Alterar os dados do submódulo informado
- Método: PUT
- Rota: `/api/submodules/{id}`
- Descrição: Altera os dados de um submódulo específico com base no ID.

#### Excluir o submódulo informado
- Método: DELETE
- Rota: `/api/submodules/{id}`
- Descrição: Exclui um submódulo com base no ID.

#### Lista todos os submódulos cadastrados
- Método: GET
- Rota: `/api/submodules/list`
- Descrição: Retorna a lista de todos os submódulos cadastrados.

#### Lista todos os submódulos cadastrados da módulo informado
- Método: GET
- Rota: `/api/submodules/list/{moduleId}`
- Descrição: Retorna a lista de todos os submódulos cadastrados de um módulo específico com base no ID do módulo.

#### Retorna os dados do submódulo informado
- Método: GET
- Rota: `/api/submodules/get/{id}`
- Descrição: Retorna os dados de um submódulo específico com base no ID.

### Usuários (USERS)

#### Cadastrar a conta de um novo usuário
- Método: POST
- Rota: `/api/users`
- Descrição: Cadastra a conta de um novo usuário.

#### Alterar os dados do usuário informado
- Método: PUT
- Rota: `/api/users/{id}`
- Descrição: Altera os dados de um usuário específico com base no ID.

#### Excluir o usuário informado
- Método: DELETE
- Rota: `/api/users/{id}`
- Descrição: Exclui um usuário com base no ID.

#### Lista todos os usuários cadastrados
- Método: GET
- Rota: `/api/users/list`
- Descrição: Retorna a lista de todos os usuários cadastrados.

#### Lista todos os usuários cadastrados da empresa informada
- Método: GET
- Rota: `/api/users/list/{companyId}`
- Descrição: Retorna a lista de todos os usuários cadastrados de uma empresa específica com base no ID da empresa.

#### Retorna os dados do usuário informado
- Método: GET
- Rota: `/api/users/get/{id}`
- Descrição: Retorna os dados de um usuário específico com base no ID.
