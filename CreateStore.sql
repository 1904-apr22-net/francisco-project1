--create schema HS;
--drop schema HS;
--drop table location;

create table store_location(
location_id int identity(1,1) primary key,
location_name nvarchar(20) not null,
location_address nvarchar(60) not null,
);

--use HardwareStoreDb;
--go
create table customer(
customer_id int identity(1,1) primary key,
first_name nvarchar(30) not null,
last_name nvarchar(30) not null,
phone_number nvarchar(20) not null,
default_location_id int
);
--go

ALTER TABLE customer    
ADD CONSTRAINT FK_customer_default_location_id FOREIGN KEY (default_location_id)     
    REFERENCES store_location (location_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
; 

create table customer_order(
order_id int identity(1,1) primary key,
order_time datetime2,
location_id int not null,
customer_id int not null,
order_total decimal not null
);

ALTER TABLE customer_order   
ADD CONSTRAINT FK_customer_order_location_id FOREIGN KEY (location_id)     
    REFERENCES store_location (location_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
; 

ALTER TABLE customer_order   
ADD CONSTRAINT FK_customer_order_customer_id FOREIGN KEY (customer_id)     
    REFERENCES customer (customer_id)     
    ON DELETE no action     
    ON UPDATE no action  
; 

create table products(
product_id int identity(1,1) primary key,
product_name nvarchar(20) not null,
product_description nvarchar(150),
product_price decimal(10,2) not null
);

create table inventory(
location_id int,
product_id int,
amount_in_stock int,
primary key (location_id, product_id)
);

ALTER TABLE inventory   
ADD CONSTRAINT FK_inventory_location_id FOREIGN KEY (location_id)     
    REFERENCES store_location (location_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
; 

ALTER TABLE inventory   
ADD CONSTRAINT FK_inventory_product_id FOREIGN KEY (product_id)     
    REFERENCES products (product_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
; 

create table order_item(
order_id int,
order_item_number int,
product_id int not null,
quantity_bought int not null,
price decimal(10,2) not null default 0,
primary key (order_id, order_item_number)
);

ALTER TABLE order_item
ADD CONSTRAINT FK_order_item_order_id FOREIGN KEY (order_id)     
    REFERENCES customer_order (order_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
; 

ALTER TABLE order_item
ADD CONSTRAINT FK_order_item_product_id FOREIGN KEY (product_id)     
    REFERENCES products (product_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
; 





