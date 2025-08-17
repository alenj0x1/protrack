--- --- --- --- --- --- scopes --- --- --- --- --- ---
create table scopes_types (
  scope_type_id serial not null primary key,
  name varchar(50) not null unique,
  show_name varchar(50) not null
);

insert into scopes_types (name, show_name)
values
('app',     'Application'),
('project', 'Project');

create table scopes (
  scope_id serial not null primary key,
  type_id int not null references scopes_types(scope_type_id),
  name varchar(50) not null unique,
  show_name varchar(50) not null,
  description varchar(100) not null default('without description')
);

insert into scopes (name, show_name, description, type_id)
values
--- app - users
('app_create_users',       'Create users',               'Allows the creation of users',               1),
('app_update_users',       'Update users',               'Allows user updates',                        1),
('app_deactivate_users',   'Deactivate users',           'Allows user deactivation',                   1),
--- app - projects                     
('app_create_projects',    'Create projects',            'Allows the creation of projects',            1),
('app_update_projects',    'Update projects',            'Allows projects to be updated'.              1),
('app_delete_projects',    'Delete projects',            'Allows the deletion of projects',            1),
--- project        
('project_update',         'Update project',             'Allows the updating of a project',           2),
('project_add_members',    'Add members',                'Allows you to add members to the project',   2),
('project_remove_members', 'Remove members',             'Allows removing members from the project',   2),
('project_ban_members',    'Ban members',                'Allows banning of members from the project', 2),
('project_create_tasks',   'Create tasks',               'Allows the creation of tasks in a project',  2),
('project_update_tasks',   'Update tasks',               'Allows tasks in a project to be updated',    2),
('project_remove_tasks',   'Remove tasks',               'Allows the removal of tasks from a project', 2);