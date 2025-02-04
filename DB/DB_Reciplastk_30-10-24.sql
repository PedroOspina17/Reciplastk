PGDMP  &                	    |         
   Reciplastk    16.3    16.4 �    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16398 
   Reciplastk    DATABASE     �   CREATE DATABASE "Reciplastk" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Colombia.1252';
    DROP DATABASE "Reciplastk";
                postgres    false                        2615    2200    public    SCHEMA     2   -- *not* creating schema, since initdb creates it
 2   -- *not* dropping schema, since initdb creates it
                postgres    false            �           0    0    SCHEMA public    ACL     Q   REVOKE USAGE ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO PUBLIC;
                   postgres    false    5            �            1259    16399    customer    TABLE     �  CREATE TABLE public.customer (
    customerid integer NOT NULL,
    nit character varying(50),
    name character varying(50) NOT NULL,
    lastname character varying(50) NOT NULL,
    address character varying(50),
    cell character varying(20),
    clientsince timestamp without time zone,
    needspickup boolean,
    createddate timestamp without time zone DEFAULT now() NOT NULL,
    updateddate timestamp without time zone,
    isactive boolean DEFAULT true,
    customertypeid integer
);
    DROP TABLE public.customer;
       public         heap    postgres    false    5            �            1259    16404    customer_customerid_seq    SEQUENCE     �   CREATE SEQUENCE public.customer_customerid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.customer_customerid_seq;
       public          postgres    false    215    5            �           0    0    customer_customerid_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.customer_customerid_seq OWNED BY public.customer.customerid;
          public          postgres    false    216            �            1259    16689    customertype    TABLE       CREATE TABLE public.customertype (
    customertypeid integer NOT NULL,
    name character varying(50) NOT NULL,
    creationdate timestamp without time zone NOT NULL,
    isactive boolean NOT NULL,
    description character varying(100),
    updatedate timestamp without time zone
);
     DROP TABLE public.customertype;
       public         heap    postgres    false    5            �            1259    16688    customertype_customertypeid_seq    SEQUENCE     �   CREATE SEQUENCE public.customertype_customertypeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.customertype_customertypeid_seq;
       public          postgres    false    244    5            �           0    0    customertype_customertypeid_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.customertype_customertypeid_seq OWNED BY public.customertype.customertypeid;
          public          postgres    false    243            �            1259    16405    employee    TABLE     �  CREATE TABLE public.employee (
    employeeid integer NOT NULL,
    roleid integer,
    name character varying(50) NOT NULL,
    lastname character varying(50) NOT NULL,
    username character varying(20) NOT NULL,
    password character varying(20) NOT NULL,
    creationdate timestamp without time zone DEFAULT now() NOT NULL,
    updateddate timestamp without time zone,
    isactive boolean DEFAULT true NOT NULL
);
    DROP TABLE public.employee;
       public         heap    postgres    false    5            �            1259    16410    employee_employeeid_seq    SEQUENCE     �   CREATE SEQUENCE public.employee_employeeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.employee_employeeid_seq;
       public          postgres    false    217    5            �           0    0    employee_employeeid_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.employee_employeeid_seq OWNED BY public.employee.employeeid;
          public          postgres    false    218            �            1259    16666    productprice    TABLE     �  CREATE TABLE public.productprice (
    productpriceid integer NOT NULL,
    productid integer NOT NULL,
    customerid integer NOT NULL,
    shortname character varying(20) NOT NULL,
    name character varying(50) NOT NULL,
    description character varying(50) NOT NULL,
    code character varying(10) NOT NULL,
    buyprice numeric NOT NULL,
    sellprice numeric NOT NULL,
    margin numeric NOT NULL,
    issubtype boolean DEFAULT false NOT NULL,
    creationdate timestamp without time zone DEFAULT now() NOT NULL,
    updatedate timestamp without time zone DEFAULT now() NOT NULL,
    isactive boolean DEFAULT true NOT NULL,
    parentid integer
);
     DROP TABLE public.productprice;
       public         heap    postgres    false    5            �            1259    16665    productprice_productpriceid_seq    SEQUENCE     �   CREATE SEQUENCE public.productprice_productpriceid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.productprice_productpriceid_seq;
       public          postgres    false    242    5            �           0    0    productprice_productpriceid_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.productprice_productpriceid_seq OWNED BY public.productprice.productpriceid;
          public          postgres    false    241            �            1259    16411    products    TABLE     �  CREATE TABLE public.products (
    productid integer NOT NULL,
    shortname character varying(50) NOT NULL,
    name character varying(50) NOT NULL,
    description character varying(150) NOT NULL,
    code character varying(10) NOT NULL,
    issubtype boolean DEFAULT false NOT NULL,
    creationdate timestamp without time zone DEFAULT now() NOT NULL,
    updatedate timestamp without time zone DEFAULT now() NOT NULL,
    isactive boolean DEFAULT true NOT NULL,
    parentid integer
);
    DROP TABLE public.products;
       public         heap    postgres    false    5            �            1259    16420    products_productid_seq    SEQUENCE     �   CREATE SEQUENCE public.products_productid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.products_productid_seq;
       public          postgres    false    5    219            �           0    0    products_productid_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.products_productid_seq OWNED BY public.products.productid;
          public          postgres    false    220            �            1259    16644 
   remainings    TABLE     <  CREATE TABLE public.remainings (
    remainingid integer NOT NULL,
    weightcontrolid integer NOT NULL,
    productid integer NOT NULL,
    weight double precision NOT NULL,
    creationdate timestamp without time zone NOT NULL,
    updatedate timestamp without time zone NOT NULL,
    isactive boolean NOT NULL
);
    DROP TABLE public.remainings;
       public         heap    postgres    false    5            �            1259    16643    remainings_remainingid_seq    SEQUENCE     �   CREATE SEQUENCE public.remainings_remainingid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.remainings_remainingid_seq;
       public          postgres    false    240    5            �           0    0    remainings_remainingid_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.remainings_remainingid_seq OWNED BY public.remainings.remainingid;
          public          postgres    false    239            �            1259    16421    rol    TABLE     �   CREATE TABLE public.rol (
    rolid integer NOT NULL,
    name character varying(50) NOT NULL,
    creationdate timestamp without time zone DEFAULT now() NOT NULL,
    updateddate timestamp without time zone,
    isactive boolean DEFAULT true NOT NULL
);
    DROP TABLE public.rol;
       public         heap    postgres    false    5            �            1259    16426    rol_rolid_seq    SEQUENCE     �   CREATE SEQUENCE public.rol_rolid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.rol_rolid_seq;
       public          postgres    false    221    5            �           0    0    rol_rolid_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.rol_rolid_seq OWNED BY public.rol.rolid;
          public          postgres    false    222            �            1259    16427    secondarytabletest    TABLE       CREATE TABLE public.secondarytabletest (
    secondarytabletestid integer NOT NULL,
    testid integer,
    description character varying(50) NOT NULL,
    isactive boolean DEFAULT true,
    createddate timestamp without time zone DEFAULT now() NOT NULL
);
 &   DROP TABLE public.secondarytabletest;
       public         heap    postgres    false    5            �            1259    16432 +   secondarytabletest_secondarytabletestid_seq    SEQUENCE     �   CREATE SEQUENCE public.secondarytabletest_secondarytabletestid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 B   DROP SEQUENCE public.secondarytabletest_secondarytabletestid_seq;
       public          postgres    false    223    5            �           0    0 +   secondarytabletest_secondarytabletestid_seq    SEQUENCE OWNED BY     {   ALTER SEQUENCE public.secondarytabletest_secondarytabletestid_seq OWNED BY public.secondarytabletest.secondarytabletestid;
          public          postgres    false    224            �            1259    16433    shipment    TABLE       CREATE TABLE public.shipment (
    shipmentid integer NOT NULL,
    customerid integer NOT NULL,
    employeeid integer NOT NULL,
    shipmenttypeid integer NOT NULL,
    shipmentstartdate timestamp without time zone NOT NULL,
    shipmentenddate timestamp without time zone NOT NULL,
    ispaid boolean NOT NULL,
    iscomplete boolean NOT NULL,
    creationdate timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updatedate timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    isactive boolean NOT NULL
);
    DROP TABLE public.shipment;
       public         heap    postgres    false    5            �            1259    16438    shipment_shipmentid_seq    SEQUENCE     �   CREATE SEQUENCE public.shipment_shipmentid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.shipment_shipmentid_seq;
       public          postgres    false    5    225            �           0    0    shipment_shipmentid_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.shipment_shipmentid_seq OWNED BY public.shipment.shipmentid;
          public          postgres    false    226            �            1259    16439    shipmentdetail    TABLE     �   CREATE TABLE public.shipmentdetail (
    shipmentdetailid integer NOT NULL,
    shipmentid integer NOT NULL,
    productid integer NOT NULL,
    shipmentdate timestamp without time zone NOT NULL,
    weight double precision NOT NULL
);
 "   DROP TABLE public.shipmentdetail;
       public         heap    postgres    false    5            �            1259    16442 #   shipmentdetail_shipmentdetailid_seq    SEQUENCE     �   CREATE SEQUENCE public.shipmentdetail_shipmentdetailid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public.shipmentdetail_shipmentdetailid_seq;
       public          postgres    false    5    227            �           0    0 #   shipmentdetail_shipmentdetailid_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public.shipmentdetail_shipmentdetailid_seq OWNED BY public.shipmentdetail.shipmentdetailid;
          public          postgres    false    228            �            1259    16443    shipmenttype    TABLE     Y  CREATE TABLE public.shipmenttype (
    shipmenttypeid integer NOT NULL,
    name character varying(50) NOT NULL,
    description character varying(50),
    creationdate timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updatedate timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    isactive boolean NOT NULL
);
     DROP TABLE public.shipmenttype;
       public         heap    postgres    false    5            �            1259    16448    shipmenttype_shipmenttypeid_seq    SEQUENCE     �   CREATE SEQUENCE public.shipmenttype_shipmenttypeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.shipmenttype_shipmenttypeid_seq;
       public          postgres    false    229    5            �           0    0    shipmenttype_shipmenttypeid_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.shipmenttype_shipmenttypeid_seq OWNED BY public.shipmenttype.shipmenttypeid;
          public          postgres    false    230            �            1259    16449    test    TABLE     �   CREATE TABLE public.test (
    testid integer NOT NULL,
    name character varying(50) NOT NULL,
    lastname character varying(50)
);
    DROP TABLE public.test;
       public         heap    postgres    false    5            �            1259    16452    test_testid_seq    SEQUENCE     �   CREATE SEQUENCE public.test_testid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.test_testid_seq;
       public          postgres    false    5    231            �           0    0    test_testid_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.test_testid_seq OWNED BY public.test.testid;
          public          postgres    false    232            �            1259    16606    weightcontrol    TABLE     �  CREATE TABLE public.weightcontrol (
    weightcontrolid integer NOT NULL,
    employeeid integer NOT NULL,
    weightcontroltypeid integer NOT NULL,
    ispaid boolean DEFAULT false NOT NULL,
    datestart timestamp without time zone NOT NULL,
    dateend timestamp without time zone NOT NULL,
    creationdate timestamp without time zone DEFAULT now() NOT NULL,
    updatedate timestamp without time zone DEFAULT now() NOT NULL,
    isactive boolean DEFAULT true NOT NULL
);
 !   DROP TABLE public.weightcontrol;
       public         heap    postgres    false    5            �            1259    16605 !   weightcontrol_weightcontrolid_seq    SEQUENCE     �   CREATE SEQUENCE public.weightcontrol_weightcontrolid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public.weightcontrol_weightcontrolid_seq;
       public          postgres    false    236    5            �           0    0 !   weightcontrol_weightcontrolid_seq    SEQUENCE OWNED BY     g   ALTER SEQUENCE public.weightcontrol_weightcontrolid_seq OWNED BY public.weightcontrol.weightcontrolid;
          public          postgres    false    235            �            1259    16627    weightcontroldetail    TABLE     �   CREATE TABLE public.weightcontroldetail (
    weightcontroldetailid integer NOT NULL,
    weightcontrolid integer NOT NULL,
    productid integer NOT NULL,
    weight double precision NOT NULL
);
 '   DROP TABLE public.weightcontroldetail;
       public         heap    postgres    false    5            �            1259    16626 -   weightcontroldetail_weightcontroldetailid_seq    SEQUENCE     �   CREATE SEQUENCE public.weightcontroldetail_weightcontroldetailid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 D   DROP SEQUENCE public.weightcontroldetail_weightcontroldetailid_seq;
       public          postgres    false    5    238            �           0    0 -   weightcontroldetail_weightcontroldetailid_seq    SEQUENCE OWNED BY        ALTER SEQUENCE public.weightcontroldetail_weightcontroldetailid_seq OWNED BY public.weightcontroldetail.weightcontroldetailid;
          public          postgres    false    237            �            1259    16565    weightcontroltype    TABLE     /  CREATE TABLE public.weightcontroltype (
    weightcontroltypeid integer NOT NULL,
    name character varying(50) NOT NULL,
    description character varying(50),
    creationdate timestamp without time zone NOT NULL,
    updatedate timestamp without time zone NOT NULL,
    isactive boolean NOT NULL
);
 %   DROP TABLE public.weightcontroltype;
       public         heap    postgres    false    5            �            1259    16564 )   weightcontroltype_weightcontroltypeid_seq    SEQUENCE     �   CREATE SEQUENCE public.weightcontroltype_weightcontroltypeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 @   DROP SEQUENCE public.weightcontroltype_weightcontroltypeid_seq;
       public          postgres    false    5    234            �           0    0 )   weightcontroltype_weightcontroltypeid_seq    SEQUENCE OWNED BY     w   ALTER SEQUENCE public.weightcontroltype_weightcontroltypeid_seq OWNED BY public.weightcontroltype.weightcontroltypeid;
          public          postgres    false    233            �           2604    16464    customer customerid    DEFAULT     z   ALTER TABLE ONLY public.customer ALTER COLUMN customerid SET DEFAULT nextval('public.customer_customerid_seq'::regclass);
 B   ALTER TABLE public.customer ALTER COLUMN customerid DROP DEFAULT;
       public          postgres    false    216    215            �           2604    16692    customertype customertypeid    DEFAULT     �   ALTER TABLE ONLY public.customertype ALTER COLUMN customertypeid SET DEFAULT nextval('public.customertype_customertypeid_seq'::regclass);
 J   ALTER TABLE public.customertype ALTER COLUMN customertypeid DROP DEFAULT;
       public          postgres    false    243    244    244            �           2604    16465    employee employeeid    DEFAULT     z   ALTER TABLE ONLY public.employee ALTER COLUMN employeeid SET DEFAULT nextval('public.employee_employeeid_seq'::regclass);
 B   ALTER TABLE public.employee ALTER COLUMN employeeid DROP DEFAULT;
       public          postgres    false    218    217            �           2604    16669    productprice productpriceid    DEFAULT     �   ALTER TABLE ONLY public.productprice ALTER COLUMN productpriceid SET DEFAULT nextval('public.productprice_productpriceid_seq'::regclass);
 J   ALTER TABLE public.productprice ALTER COLUMN productpriceid DROP DEFAULT;
       public          postgres    false    242    241    242            �           2604    16466    products productid    DEFAULT     x   ALTER TABLE ONLY public.products ALTER COLUMN productid SET DEFAULT nextval('public.products_productid_seq'::regclass);
 A   ALTER TABLE public.products ALTER COLUMN productid DROP DEFAULT;
       public          postgres    false    220    219            �           2604    16647    remainings remainingid    DEFAULT     �   ALTER TABLE ONLY public.remainings ALTER COLUMN remainingid SET DEFAULT nextval('public.remainings_remainingid_seq'::regclass);
 E   ALTER TABLE public.remainings ALTER COLUMN remainingid DROP DEFAULT;
       public          postgres    false    240    239    240            �           2604    16467 	   rol rolid    DEFAULT     f   ALTER TABLE ONLY public.rol ALTER COLUMN rolid SET DEFAULT nextval('public.rol_rolid_seq'::regclass);
 8   ALTER TABLE public.rol ALTER COLUMN rolid DROP DEFAULT;
       public          postgres    false    222    221            �           2604    16468 '   secondarytabletest secondarytabletestid    DEFAULT     �   ALTER TABLE ONLY public.secondarytabletest ALTER COLUMN secondarytabletestid SET DEFAULT nextval('public.secondarytabletest_secondarytabletestid_seq'::regclass);
 V   ALTER TABLE public.secondarytabletest ALTER COLUMN secondarytabletestid DROP DEFAULT;
       public          postgres    false    224    223            �           2604    16469    shipment shipmentid    DEFAULT     z   ALTER TABLE ONLY public.shipment ALTER COLUMN shipmentid SET DEFAULT nextval('public.shipment_shipmentid_seq'::regclass);
 B   ALTER TABLE public.shipment ALTER COLUMN shipmentid DROP DEFAULT;
       public          postgres    false    226    225            �           2604    16470    shipmentdetail shipmentdetailid    DEFAULT     �   ALTER TABLE ONLY public.shipmentdetail ALTER COLUMN shipmentdetailid SET DEFAULT nextval('public.shipmentdetail_shipmentdetailid_seq'::regclass);
 N   ALTER TABLE public.shipmentdetail ALTER COLUMN shipmentdetailid DROP DEFAULT;
       public          postgres    false    228    227            �           2604    16471    shipmenttype shipmenttypeid    DEFAULT     �   ALTER TABLE ONLY public.shipmenttype ALTER COLUMN shipmenttypeid SET DEFAULT nextval('public.shipmenttype_shipmenttypeid_seq'::regclass);
 J   ALTER TABLE public.shipmenttype ALTER COLUMN shipmenttypeid DROP DEFAULT;
       public          postgres    false    230    229            �           2604    16472    test testid    DEFAULT     j   ALTER TABLE ONLY public.test ALTER COLUMN testid SET DEFAULT nextval('public.test_testid_seq'::regclass);
 :   ALTER TABLE public.test ALTER COLUMN testid DROP DEFAULT;
       public          postgres    false    232    231            �           2604    16609    weightcontrol weightcontrolid    DEFAULT     �   ALTER TABLE ONLY public.weightcontrol ALTER COLUMN weightcontrolid SET DEFAULT nextval('public.weightcontrol_weightcontrolid_seq'::regclass);
 L   ALTER TABLE public.weightcontrol ALTER COLUMN weightcontrolid DROP DEFAULT;
       public          postgres    false    236    235    236            �           2604    16630 )   weightcontroldetail weightcontroldetailid    DEFAULT     �   ALTER TABLE ONLY public.weightcontroldetail ALTER COLUMN weightcontroldetailid SET DEFAULT nextval('public.weightcontroldetail_weightcontroldetailid_seq'::regclass);
 X   ALTER TABLE public.weightcontroldetail ALTER COLUMN weightcontroldetailid DROP DEFAULT;
       public          postgres    false    238    237    238            �           2604    16568 %   weightcontroltype weightcontroltypeid    DEFAULT     �   ALTER TABLE ONLY public.weightcontroltype ALTER COLUMN weightcontroltypeid SET DEFAULT nextval('public.weightcontroltype_weightcontroltypeid_seq'::regclass);
 T   ALTER TABLE public.weightcontroltype ALTER COLUMN weightcontroltypeid DROP DEFAULT;
       public          postgres    false    233    234    234            {          0    16399    customer 
   TABLE DATA           �   COPY public.customer (customerid, nit, name, lastname, address, cell, clientsince, needspickup, createddate, updateddate, isactive, customertypeid) FROM stdin;
    public          postgres    false    215   Ƭ       �          0    16689    customertype 
   TABLE DATA           m   COPY public.customertype (customertypeid, name, creationdate, isactive, description, updatedate) FROM stdin;
    public          postgres    false    244   ߯       }          0    16405    employee 
   TABLE DATA              COPY public.employee (employeeid, roleid, name, lastname, username, password, creationdate, updateddate, isactive) FROM stdin;
    public          postgres    false    217   k�       �          0    16666    productprice 
   TABLE DATA           �   COPY public.productprice (productpriceid, productid, customerid, shortname, name, description, code, buyprice, sellprice, margin, issubtype, creationdate, updatedate, isactive, parentid) FROM stdin;
    public          postgres    false    242   ��                 0    16411    products 
   TABLE DATA           �   COPY public.products (productid, shortname, name, description, code, issubtype, creationdate, updatedate, isactive, parentid) FROM stdin;
    public          postgres    false    219   ݰ       �          0    16644 
   remainings 
   TABLE DATA           y   COPY public.remainings (remainingid, weightcontrolid, productid, weight, creationdate, updatedate, isactive) FROM stdin;
    public          postgres    false    240   ȴ       �          0    16421    rol 
   TABLE DATA           O   COPY public.rol (rolid, name, creationdate, updateddate, isactive) FROM stdin;
    public          postgres    false    221   T�       �          0    16427    secondarytabletest 
   TABLE DATA           n   COPY public.secondarytabletest (secondarytabletestid, testid, description, isactive, createddate) FROM stdin;
    public          postgres    false    223   ĸ       �          0    16433    shipment 
   TABLE DATA           �   COPY public.shipment (shipmentid, customerid, employeeid, shipmenttypeid, shipmentstartdate, shipmentenddate, ispaid, iscomplete, creationdate, updatedate, isactive) FROM stdin;
    public          postgres    false    225   A�       �          0    16439    shipmentdetail 
   TABLE DATA           g   COPY public.shipmentdetail (shipmentdetailid, shipmentid, productid, shipmentdate, weight) FROM stdin;
    public          postgres    false    227   Ѻ       �          0    16443    shipmenttype 
   TABLE DATA           m   COPY public.shipmenttype (shipmenttypeid, name, description, creationdate, updatedate, isactive) FROM stdin;
    public          postgres    false    229   �       �          0    16449    test 
   TABLE DATA           6   COPY public.test (testid, name, lastname) FROM stdin;
    public          postgres    false    231   ��       �          0    16606    weightcontrol 
   TABLE DATA           �   COPY public.weightcontrol (weightcontrolid, employeeid, weightcontroltypeid, ispaid, datestart, dateend, creationdate, updatedate, isactive) FROM stdin;
    public          postgres    false    236   �       �          0    16627    weightcontroldetail 
   TABLE DATA           h   COPY public.weightcontroldetail (weightcontroldetailid, weightcontrolid, productid, weight) FROM stdin;
    public          postgres    false    238   l�       �          0    16565    weightcontroltype 
   TABLE DATA           w   COPY public.weightcontroltype (weightcontroltypeid, name, description, creationdate, updatedate, isactive) FROM stdin;
    public          postgres    false    234   G�       �           0    0    customer_customerid_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.customer_customerid_seq', 44, true);
          public          postgres    false    216            �           0    0    customertype_customertypeid_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.customertype_customertypeid_seq', 2, true);
          public          postgres    false    243            �           0    0    employee_employeeid_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.employee_employeeid_seq', 29, true);
          public          postgres    false    218            �           0    0    productprice_productpriceid_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.productprice_productpriceid_seq', 1, false);
          public          postgres    false    241            �           0    0    products_productid_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.products_productid_seq', 40, true);
          public          postgres    false    220            �           0    0    remainings_remainingid_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.remainings_remainingid_seq', 59, true);
          public          postgres    false    239            �           0    0    rol_rolid_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.rol_rolid_seq', 3, true);
          public          postgres    false    222            �           0    0 +   secondarytabletest_secondarytabletestid_seq    SEQUENCE SET     Y   SELECT pg_catalog.setval('public.secondarytabletest_secondarytabletestid_seq', 3, true);
          public          postgres    false    224            �           0    0    shipment_shipmentid_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.shipment_shipmentid_seq', 18, true);
          public          postgres    false    226            �           0    0 #   shipmentdetail_shipmentdetailid_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public.shipmentdetail_shipmentdetailid_seq', 28, true);
          public          postgres    false    228            �           0    0    shipmenttype_shipmenttypeid_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.shipmenttype_shipmenttypeid_seq', 2, true);
          public          postgres    false    230            �           0    0    test_testid_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.test_testid_seq', 11, true);
          public          postgres    false    232            �           0    0 !   weightcontrol_weightcontrolid_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.weightcontrol_weightcontrolid_seq', 89, true);
          public          postgres    false    235            �           0    0 -   weightcontroldetail_weightcontroldetailid_seq    SEQUENCE SET     \   SELECT pg_catalog.setval('public.weightcontroldetail_weightcontroldetailid_seq', 94, true);
          public          postgres    false    237            �           0    0 )   weightcontroltype_weightcontroltypeid_seq    SEQUENCE SET     X   SELECT pg_catalog.setval('public.weightcontroltype_weightcontroltypeid_seq', 11, true);
          public          postgres    false    233            �           2606    16475    customer customer_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.customer
    ADD CONSTRAINT customer_pkey PRIMARY KEY (customerid);
 @   ALTER TABLE ONLY public.customer DROP CONSTRAINT customer_pkey;
       public            postgres    false    215            �           2606    16694    customertype customertype_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.customertype
    ADD CONSTRAINT customertype_pkey PRIMARY KEY (customertypeid);
 H   ALTER TABLE ONLY public.customertype DROP CONSTRAINT customertype_pkey;
       public            postgres    false    244            �           2606    16477    employee employee_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (employeeid);
 @   ALTER TABLE ONLY public.employee DROP CONSTRAINT employee_pkey;
       public            postgres    false    217            �           2606    16677    productprice productprice_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.productprice
    ADD CONSTRAINT productprice_pkey PRIMARY KEY (productpriceid);
 H   ALTER TABLE ONLY public.productprice DROP CONSTRAINT productprice_pkey;
       public            postgres    false    242            �           2606    16479    products products_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (productid);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public            postgres    false    219            �           2606    16649    remainings remainings_pkey 
   CONSTRAINT     a   ALTER TABLE ONLY public.remainings
    ADD CONSTRAINT remainings_pkey PRIMARY KEY (remainingid);
 D   ALTER TABLE ONLY public.remainings DROP CONSTRAINT remainings_pkey;
       public            postgres    false    240            �           2606    16481    rol rol_pkey 
   CONSTRAINT     M   ALTER TABLE ONLY public.rol
    ADD CONSTRAINT rol_pkey PRIMARY KEY (rolid);
 6   ALTER TABLE ONLY public.rol DROP CONSTRAINT rol_pkey;
       public            postgres    false    221            �           2606    16483 *   secondarytabletest secondarytabletest_pkey 
   CONSTRAINT     z   ALTER TABLE ONLY public.secondarytabletest
    ADD CONSTRAINT secondarytabletest_pkey PRIMARY KEY (secondarytabletestid);
 T   ALTER TABLE ONLY public.secondarytabletest DROP CONSTRAINT secondarytabletest_pkey;
       public            postgres    false    223            �           2606    16485    shipment shipment_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.shipment
    ADD CONSTRAINT shipment_pkey PRIMARY KEY (shipmentid);
 @   ALTER TABLE ONLY public.shipment DROP CONSTRAINT shipment_pkey;
       public            postgres    false    225            �           2606    16487 "   shipmentdetail shipmentdetail_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.shipmentdetail
    ADD CONSTRAINT shipmentdetail_pkey PRIMARY KEY (shipmentdetailid);
 L   ALTER TABLE ONLY public.shipmentdetail DROP CONSTRAINT shipmentdetail_pkey;
       public            postgres    false    227            �           2606    16489    shipmenttype shipmenttype_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.shipmenttype
    ADD CONSTRAINT shipmenttype_pkey PRIMARY KEY (shipmenttypeid);
 H   ALTER TABLE ONLY public.shipmenttype DROP CONSTRAINT shipmenttype_pkey;
       public            postgres    false    229            �           2606    16491    test test_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.test
    ADD CONSTRAINT test_pkey PRIMARY KEY (testid);
 8   ALTER TABLE ONLY public.test DROP CONSTRAINT test_pkey;
       public            postgres    false    231            �           2606    16615     weightcontrol weightcontrol_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public.weightcontrol
    ADD CONSTRAINT weightcontrol_pkey PRIMARY KEY (weightcontrolid);
 J   ALTER TABLE ONLY public.weightcontrol DROP CONSTRAINT weightcontrol_pkey;
       public            postgres    false    236            �           2606    16632 ,   weightcontroldetail weightcontroldetail_pkey 
   CONSTRAINT     }   ALTER TABLE ONLY public.weightcontroldetail
    ADD CONSTRAINT weightcontroldetail_pkey PRIMARY KEY (weightcontroldetailid);
 V   ALTER TABLE ONLY public.weightcontroldetail DROP CONSTRAINT weightcontroldetail_pkey;
       public            postgres    false    238            �           2606    16570 (   weightcontroltype weightcontroltype_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public.weightcontroltype
    ADD CONSTRAINT weightcontroltype_pkey PRIMARY KEY (weightcontroltypeid);
 R   ALTER TABLE ONLY public.weightcontroltype DROP CONSTRAINT weightcontroltype_pkey;
       public            postgres    false    234            �           2606    16494    employee employee_roleid_fkey    FK CONSTRAINT     |   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_roleid_fkey FOREIGN KEY (roleid) REFERENCES public.rol(rolid);
 G   ALTER TABLE ONLY public.employee DROP CONSTRAINT employee_roleid_fkey;
       public          postgres    false    217    4804    221            �           2606    16695    customer fk_customer_type    FK CONSTRAINT     �   ALTER TABLE ONLY public.customer
    ADD CONSTRAINT fk_customer_type FOREIGN KEY (customertypeid) REFERENCES public.customertype(customertypeid) ON UPDATE CASCADE ON DELETE CASCADE;
 C   ALTER TABLE ONLY public.customer DROP CONSTRAINT fk_customer_type;
       public          postgres    false    244    215    4826            �           2606    16683 )   productprice productprice_customerid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.productprice
    ADD CONSTRAINT productprice_customerid_fkey FOREIGN KEY (customerid) REFERENCES public.customer(customerid);
 S   ALTER TABLE ONLY public.productprice DROP CONSTRAINT productprice_customerid_fkey;
       public          postgres    false    242    215    4798            �           2606    16678 (   productprice productprice_productid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.productprice
    ADD CONSTRAINT productprice_productid_fkey FOREIGN KEY (productid) REFERENCES public.products(productid);
 R   ALTER TABLE ONLY public.productprice DROP CONSTRAINT productprice_productid_fkey;
       public          postgres    false    242    219    4802            �           2606    16660    products products_parentid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_parentid_fkey FOREIGN KEY (parentid) REFERENCES public.products(productid);
 I   ALTER TABLE ONLY public.products DROP CONSTRAINT products_parentid_fkey;
       public          postgres    false    219    219    4802            �           2606    16655 $   remainings remainings_productid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.remainings
    ADD CONSTRAINT remainings_productid_fkey FOREIGN KEY (productid) REFERENCES public.products(productid);
 N   ALTER TABLE ONLY public.remainings DROP CONSTRAINT remainings_productid_fkey;
       public          postgres    false    4802    240    219            �           2606    16650 *   remainings remainings_weightcontrolid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.remainings
    ADD CONSTRAINT remainings_weightcontrolid_fkey FOREIGN KEY (weightcontrolid) REFERENCES public.weightcontrol(weightcontrolid);
 T   ALTER TABLE ONLY public.remainings DROP CONSTRAINT remainings_weightcontrolid_fkey;
       public          postgres    false    236    240    4818            �           2606    16499 1   secondarytabletest secondarytabletest_testid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.secondarytabletest
    ADD CONSTRAINT secondarytabletest_testid_fkey FOREIGN KEY (testid) REFERENCES public.test(testid);
 [   ALTER TABLE ONLY public.secondarytabletest DROP CONSTRAINT secondarytabletest_testid_fkey;
       public          postgres    false    223    4814    231            �           2606    16504 !   shipment shipment_customerid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.shipment
    ADD CONSTRAINT shipment_customerid_fkey FOREIGN KEY (customerid) REFERENCES public.customer(customerid);
 K   ALTER TABLE ONLY public.shipment DROP CONSTRAINT shipment_customerid_fkey;
       public          postgres    false    225    4798    215            �           2606    16509 !   shipment shipment_employeeid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.shipment
    ADD CONSTRAINT shipment_employeeid_fkey FOREIGN KEY (employeeid) REFERENCES public.employee(employeeid);
 K   ALTER TABLE ONLY public.shipment DROP CONSTRAINT shipment_employeeid_fkey;
       public          postgres    false    225    4800    217            �           2606    16514 %   shipment shipment_shipmenttypeid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.shipment
    ADD CONSTRAINT shipment_shipmenttypeid_fkey FOREIGN KEY (shipmenttypeid) REFERENCES public.shipmenttype(shipmenttypeid);
 O   ALTER TABLE ONLY public.shipment DROP CONSTRAINT shipment_shipmenttypeid_fkey;
       public          postgres    false    229    225    4812            �           2606    16519 ,   shipmentdetail shipmentdetail_productid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.shipmentdetail
    ADD CONSTRAINT shipmentdetail_productid_fkey FOREIGN KEY (productid) REFERENCES public.products(productid);
 V   ALTER TABLE ONLY public.shipmentdetail DROP CONSTRAINT shipmentdetail_productid_fkey;
       public          postgres    false    227    4802    219            �           2606    16524 -   shipmentdetail shipmentdetail_shipmentid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.shipmentdetail
    ADD CONSTRAINT shipmentdetail_shipmentid_fkey FOREIGN KEY (shipmentid) REFERENCES public.shipment(shipmentid);
 W   ALTER TABLE ONLY public.shipmentdetail DROP CONSTRAINT shipmentdetail_shipmentid_fkey;
       public          postgres    false    225    4808    227            �           2606    16616 +   weightcontrol weightcontrol_employeeid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.weightcontrol
    ADD CONSTRAINT weightcontrol_employeeid_fkey FOREIGN KEY (employeeid) REFERENCES public.employee(employeeid);
 U   ALTER TABLE ONLY public.weightcontrol DROP CONSTRAINT weightcontrol_employeeid_fkey;
       public          postgres    false    4800    217    236            �           2606    16621 4   weightcontrol weightcontrol_weightcontroltypeid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.weightcontrol
    ADD CONSTRAINT weightcontrol_weightcontroltypeid_fkey FOREIGN KEY (weightcontroltypeid) REFERENCES public.weightcontroltype(weightcontroltypeid);
 ^   ALTER TABLE ONLY public.weightcontrol DROP CONSTRAINT weightcontrol_weightcontroltypeid_fkey;
       public          postgres    false    236    234    4816            �           2606    16638 6   weightcontroldetail weightcontroldetail_productid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.weightcontroldetail
    ADD CONSTRAINT weightcontroldetail_productid_fkey FOREIGN KEY (productid) REFERENCES public.products(productid);
 `   ALTER TABLE ONLY public.weightcontroldetail DROP CONSTRAINT weightcontroldetail_productid_fkey;
       public          postgres    false    219    238    4802            �           2606    16633 <   weightcontroldetail weightcontroldetail_weightcontrolid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.weightcontroldetail
    ADD CONSTRAINT weightcontroldetail_weightcontrolid_fkey FOREIGN KEY (weightcontrolid) REFERENCES public.weightcontrol(weightcontrolid);
 f   ALTER TABLE ONLY public.weightcontroldetail DROP CONSTRAINT weightcontroldetail_weightcontrolid_fkey;
       public          postgres    false    236    4818    238            {   	  x��VMoG=�~� >k��������s�EI�B�"����v�Y�%�$�@-����$�E�_�_������q���G�� Q�bV�@@���&��MrJ�����_�$J�����'�?|ZQ���m��9c�;Xgu(�j��L��9Bi
MK�N���.HL�����u���9^�$�i^;���Do�z>�scK���s��J�h�3���qw��͟E"iZ��꥞n�T:w��4R���==�	�;s��{c�Ҡ&&�E��ڠ$dV��ϕ�Q���8	_v���}���O��bn�;�5)�|-rY4ރ�2vv}Ur�?|?n7>�w��01*�X�x��QN�P��%�,X;��RI��;��pLl�W��A�������w����x�����syX��uP�"�4�TY3�ky�0��ZYn?���s��y�����5\W=J�J�'�Zgۂ���d�W���6ͩ�{Eu�f[>$T��D$e}!=��#�룠؝��f�Ύ����X#@;�č8��$P�����:A��Y�ǒ��6'nt�v4<��|5f¿�	Ck����L���)>�.������j@T���X�8;H̉P�v�P�����©� .q�v�.��O��6��e���*!N!�D����������N��\^������$�b6��y�07�AA�l8��^g�6�0�,d���B��=�5��)�M<$��>��/|��#T��5�R�*�����k���@���qM�ng4���!�V�����      �   |   x�e�;� ��\��eȴ����@�ca+EN�"��7o���׋O0����X�f�)D���k+G�{�|��;�*l�����<���HY��'�c�5r��k��|��I���SlJ�b?+r      }   E   x�3��4�tI,�L��/.N�0�A,CCN##]c]#3Cs+cC+#S=3scKs�?��=... U��      �      x������ � �         �  x���K��8���)x����^�t�e��*Z�=
Ԓ@����,��)R�e�Іga�X%��YU$-Q��A����δ]U�E���u�Q0~�^���E�U��P��%Xz(!��#b��'?��8Y��H�b������k��*Z'F�z���k|TS0H���E�Z�
��:x~�������&G�(���r+��P�
e��A��O�U�-��к4�:��r،�(&"g$g<��&�m����P�~V%�S5��c��}?�y	���w�&h���mWQ���>�VC��=,ǖw̦M�:����2X�c#�:y�EIrG	!�X�*4�N�oUi��?�_��fs�J���U?覨p	K��.��\��`Q�d����X�$ &P �s���>�u���k�Nv̈́�E{�-��E�Ș��O'�~1��;eܮ��F|M��U'�.�t�R��h6S�\��XK�MdU]x��b���_t}�'�*kXU��q��c���?�����:���@+�?��
����w��s8���䡭{��T�k|����bkG�$&2!�V���h���7.�6r�h���aqDD����87�����_,+x,�>�dt	L[�@�ێ8:,�=���s�3�������49Ѿ�F�aMWG��2��M�R���v��a��� ���g�C]]B��E�T�Ɵڦ-*�
܉;,ڜ%�dQ��[��K�˟�[����ќȈ%L��Vh�?�f�d08V��y��epfs�؍a�2���}p��9���獱�>�^˅L���'���o`n�NHNe$3���V���Mw�x�������= m�=�%�٣�M��,�r/Ex�;F�7��iA�B��4����a˓�^D������z�H���{��	sv�<�Y�$���������ʕ��tZV��bx���EL(��ʵ�tbV��1�EL��b�+�b�ӉYi�����-�J��_��h������      �   |  x�m�=nc;�ky�@�O$�Z� �TӼݿC[t A�O$u��K�|Ȱ������Ͽ�����ƃb�Ak�b�X���Nz�_*��r���&��@֝���2����t�"��夵y�m�Ḵ�L��$s�q7�~	M�������p\�S]X� bpT>� ad�vF��Yo�� Z��+/�l��{�YS�E�/���U99B��Q��"EX'�ZU��}&E<D_�~%�'g�'!CJ���F����EH'��-���!5��[�������'�2��ZRh���[��$��刡�����]n'�C	�{'?Ĉ�3+Ƞ\}{>�^��{�^�`0-ɭ<��y���%�[ � �����'�cR�Ft�~����`BMmL�z�A�����b.';���Χ�;�ge��?��`�mM�(7�?��hU��N�Nh�r�a5��;a�������������5�K��O��0�?�A<�ʦ��������NT��k���Hh�D@A�Ӎ�t؇��� c,d��N�p���`V�M$��B���r�@^JSd��h������f�2oU�;�7�U��/�<]��C�1z ��l���d�u�[J �Tu2/]�sRz���J�#�7�>���<�/raK��T��� ^����1��fxl�Ã�|$��.���B7FJ���!��mL�6dF(�u7\�K5�絚;C����O�ZR����p9��H|	��b�mT&�?����YL�����8�	��uv �];�Y��	H����d�g�esc8L����O��d�*t���2���.z]�_H����|"{Du��ɇv�>=�{!>�K�7�K�M�?c��I��`1����#j��u"j"0��&�׼�n���s�      �   `   x�]�1�  ����@ڊx�/p�@�b���1:�_� �����V#kƁ1댠'oa]�V��-�R;�6�3$4���#l5�=�p~O�"���(�i�>      �   m   x�}̱
�0 ���+����jMv�[�.q�M)��t����{���6ͦ�A,M���㐅�D�Z	�J��j�F�0ب�����w\r��fJ�H$���xy="�      �   �  x�}�K�� @ѱYE6J}Y��
��j�yw0r%��(�}k�5�pk��	�z �n��=�޷?�p��?.v��Jڄ�Lj�RR^���+h�;�gmMj���2��l�L��h/��mt����d�v�V@�k�ڋ&mn{5C���'�"�V]����h/v����=�֒v�����^|��++����|�\���d�����[,���4'_������L�x���$�'�1��e���H���,���K����\���������:�E<�E��?�A^c�e4�������Γ"~��.���x�0�1X&���[�bS�~G��,��B�1qN�s��]��Eܮ�N���o?���L�k��	��^~j)�/��H      �   *  x�}�;n�0 Й:E.`�R:K�Y:u��K9m8u��x��Ro�~�_?��_��ֻ�L�U�Q�6��=���U�,b�Ⱥ��P/�S}�w�L�l��X2�7�d�*E�����3q95i7%��*�DGr�J��⩜�$�l4vd����-��w�0�l���tC	5��>F"��#T�?�p#Z�kƮ�R�d�V���U�h1�߽�YL��>H�M^2q˦P��?�r!�*Ӱ�	ܸ*;԰�j?�d-�HjL�X���Uuc�vP1Q{�{�{�\���T胭����[kߓՕ]      �   �   x���1
�0@��>�.#Yr��w�\��E�&�ߟ�:w��ᓻ��ގ�]־[5�^��>���s�m21ʀ:� qIZH���R�X8�S5��2Ws��v��O��I)��
�p��E�`8����y����4N      �   b   x�3�tI,�L��/.N�2�t�ɬJLJ-����KI-Hy%
>�啩E\���)E�@��y�
�E�ə�y�\&��y)E����P���sS��b���� =�$      �   C  x��YK��\�O�8!�D�������7s�	*����R��)R$U�����ǯ?����ϟ��^�ō�W�(~R{4z4?Z�>�;���_���썿��~HN*��������"�n����_n)�U��k	��yqd������}Ҩ�j�����G�F��x4�x?*�Рf���}�}}�������aq�!�U L�1��2>�0qn����Ŧ�H����]*c���6��lT��wz#v*$+{�=���ʕ3z���ڹ*'�=7��!�h��8��Bd	� H=el%CՇ�Ѷ<�+�[#_@q�@(e�F&��4��n5�`Y@��#�*?���z���0�,������/��pM���'��;nB�=�pDx�1�P���?[�Ւv�4��b�I�t	nm�4�v�������4,��x~'E���o ��V�6�b�VSH����S��2j����d>I}�> �z:������ٴwR_C�I���,�������5�46��(pҘ��5���̅dkYy��x�<O��k�g�l��L�'-p����O�2/R��r���L�&�u�kh���$��t�*��	���;ln��s%uY t����idZ@+*8@�$��d�r!��"-�L�P�T�r(&���|��>���c�� ��3�qm�vڭ�4�H����F%�|g'.a�"����VE���_`A*k���&��,�Q�!5X�Ԓw�)KyB�Z�4G<��#�od^���R��f���6��t�N��e#YiHlTb�y�׺iA��Zʬ�?hvV�:�6W��kU��hۨpV
����+����aye�62��_cþY�����HF�.�f������wGs%�	Xs�,��nzm�K�F�5�D-@��Y��kp���|��b��0�
@�0i�*�cMf�mn� ti ��sg3�����HЭ�L�4�?�)��4�Rh.8�*��hNg���h~ZR4�=��֊����N���F�5�^�!��줭:�l�u̾B�朗.�P��؎i��Йg7j����5;d8��M=deհ���@(��=�j��p9z7��w@ֆ���}M�A;ե���u�,��������r�m�uPو
�����pҲ��Г��n����U����FY�%ԵO�j23�����j�B7����~Q.�v�`�n�ГֳԂ爎�+�Lo�};�hYs����ͷ���D�PK������f ߬&����Q�N3�{Fvk]7.�z�*���p+S��t����Y�F����l8���(ik�U�t��'N\Vq�N'~��{B�x:�*z�4iL*�<�jv���1�K���@̍�$�*z�6�	�F�������kT�
$���U�9=���2����ݝ�G�ʠϧ�U�9i�f�ب�Kk���&��5����۪��	Y�f6܀{�h���w�x���z�c��$�|�n<'GbG�v�5��gBH��F-��'d��t�9�f���[60wR	���}��2���@<�g۰�y���zBh-�Q��ze�����ٺ�����L(�A!�����!$� �H_@[�M�v��� ����Zk��B��=���a_4�u�F1m��a�[M�If���Ru�P���Q����U��t��bNN�+D��}���WQx;�Z,_!C#�&����E��6bT�ɳ�o(a�f�'���d�����'-mD@�O��/�FTB�5j�4�h�B��w}�nw$��FWϻ��h�˭�3i(��1�	�/�a]�ֈ���_F��1��K�F-o����*«7�;�ͯ�P�|��q�ayY�ƉZ��^ n�N����P�i�r9�f3�4���Cu%��9�A��|��='m���,��˼H�A�A��"�fh/��O����!+���eY��F��эtm����`}�nd4spM����m �=��md,H�<��ռHe5O��,}�\WӴ�
��ڸ}A�҈ۥ8-�v�jOs�bNOZ��l�/�/Y�����F� �S�1+�(�ēY�0�$�/�z>a�FY٤B`�䣔J_��@f�7����p[�����L�h���;>>>����      �   �  x�5�[�e!E�a0���\j���z�Jj��!6d���q��%6��O�X�]h��>���� �'������N}�����X6�g#W<�+v�c�^^�;IK�7
�������'��ă�R� j�
��3ǈ�so�N?"͕���u��1��L�½u�#t��n0���M��U�����b.]OB��I��Լ]MRO���̞i��Tv��h�}���]&<_E3Yg���ys5>���äXԤ���c�Z9�(�9���M"�Q֔g��j���WW����(�VUKX&���t�@c����i�n����Z�.�-�bl4�2�G�L�7�����}#�k�џ�٦���F_�o�X�nNƳ@���>�.L��+�D��}�Ws\䚐z�kk��S�]'����x���u3�f
���#��A��9/%���z�9.hw;����WXS���S���_�      �   3  x�u��n�0Dk�+�Z���s��I�ƅ"��8B��}V�/:6Kofv�dV������7�l[L-�0[΄�l�bM��~�o�k�<ӡ<�X���w���[�Y.��/����DŊ
�u\������ �ȳ��[E����ﺮ���Â�r�7O$���GUs����v^"��щ|��YE�9���m��j�8+a�L]LX7�����)A"I�'��������n}vb�d}Ű���-w��FZw�fn��,�$�WB�2��xLK�
�.df�`����������]&�T����@�4?z�
     