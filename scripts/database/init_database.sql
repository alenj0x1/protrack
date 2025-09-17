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
('app_update_projects',    'Update projects',            'Allows projects to be updated',              1),
('app_delete_projects',    'Delete projects',            'Allows the deletion of projects',            1),
--- project        
('project_update',         'Update project',             'Allows the updating of a project',           2),
('project_add_members',    'Add members',                'Allows you to add members to the project',   2),
('project_remove_members', 'Remove members',             'Allows removing members from the project',   2),
('project_ban_members',    'Ban members',                'Allows banning of members from the project', 2),
('project_create_tasks',   'Create tasks',               'Allows the creation of tasks in a project',  2),
('project_update_tasks',   'Update tasks',               'Allows tasks in a project to be updated',    2),
('project_remove_tasks',   'Remove tasks',               'Allows the removal of tasks from a project', 2);

--- --- --- --- --- --- users --- --- --- --- --- ---
create table users (
  user_id uuid not null primary key default(gen_random_uuid()),
  username varchar(32) not null,
  email_address varchar(255) not null,
  password varchar(255) not null,
  mfa_authenticated boolean not null default(false),
  mfa_enabled boolean not null default(false),
  login_attemps int not null default(5),
  created_at timestamp not null default(now()),
  created_by uuid references users(user_id),
  updated_at timestamp not null default(now()),
  updated_by uuid references users(user_id),
  deleted_at timestamp,
  deleted_by uuid references users(user_id)
);

--- --- --- --- --- --- files --- --- --- --- --- ---
create table app_files (
  app_file_id uuid not null primary key default(gen_random_uuid()),
  name varchar(255) not null,
  relative_path varchar(255) not null,
  is_temporal boolean not null default(true),
  size bigint not null,
  uploaded_at timestamp not null default(now()),
  uploaded_by uuid references users(user_id)
);

--- --- --- --- --- --- users / profiles --- --- --- --- --- ---
create table users_profiles (
  user_profile_id serial primary key not null,
  display_name varchar(54),
  first_name varchar(100),
  last_name varchar(100),
  avatar_id uuid references app_files(app_file_id) on delete set null,
  created_at timestamp not null default(now()),
  updated_at timestamp not null default(now())
);