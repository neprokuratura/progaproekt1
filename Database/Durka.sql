PGDMP      -                |            Durka    16.3    16.3 9    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    24576    Durka    DATABASE     {   CREATE DATABASE "Durka" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Durka";
                postgres    false            �            1259    24592    account    TABLE     �   CREATE TABLE public.account (
    id integer NOT NULL,
    login character varying(20) NOT NULL,
    password character varying(20) NOT NULL,
    status boolean NOT NULL
);
    DROP TABLE public.account;
       public         heap    postgres    false            �            1259    24641    account_id_seq    SEQUENCE     �   ALTER TABLE public.account ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.account_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �            1259    24583    chamber    TABLE     �   CREATE TABLE public.chamber (
    id integer NOT NULL,
    capacity integer NOT NULL,
    type character varying(30) NOT NULL,
    area integer NOT NULL
);
    DROP TABLE public.chamber;
       public         heap    postgres    false            �            1259    24586 	   diagnosis    TABLE     �   CREATE TABLE public.diagnosis (
    id integer NOT NULL,
    severeness character varying(20) NOT NULL,
    description character varying(100),
    drug_id integer,
    name character varying(30) NOT NULL
);
    DROP TABLE public.diagnosis;
       public         heap    postgres    false            �            1259    24635    diagnoz_id_seq    SEQUENCE     �   ALTER TABLE public.diagnosis ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.diagnoz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218            �            1259    24580    doctor    TABLE     i  CREATE TABLE public.doctor (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    third_name character varying(20),
    specialization character varying(50) NOT NULL,
    account_id integer NOT NULL,
    cabinet_number integer NOT NULL,
    phone_number integer NOT NULL,
    age integer NOT NULL
);
    DROP TABLE public.doctor;
       public         heap    postgres    false            �            1259    24595    doctor_and_patient    TABLE     �   CREATE TABLE public.doctor_and_patient (
    id integer NOT NULL,
    doctor_id integer NOT NULL,
    patient_id integer NOT NULL
);
 &   DROP TABLE public.doctor_and_patient;
       public         heap    postgres    false            �            1259    24589    drug    TABLE     �   CREATE TABLE public.drug (
    id integer NOT NULL,
    name character varying(30) NOT NULL,
    dose_type character varying(10) NOT NULL,
    type character varying(20) NOT NULL,
    dose integer NOT NULL
);
    DROP TABLE public.drug;
       public         heap    postgres    false            �            1259    24627    palata_id_seq    SEQUENCE     �   ALTER TABLE public.chamber ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.palata_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    24577    patient    TABLE     -  CREATE TABLE public.patient (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    third_name character varying(20),
    chamber_id integer NOT NULL,
    rating integer NOT NULL,
    account_id integer NOT NULL,
    age integer NOT NULL
);
    DROP TABLE public.patient;
       public         heap    postgres    false            �            1259    24598    patient_and_diagnosis    TABLE     �   CREATE TABLE public.patient_and_diagnosis (
    id integer NOT NULL,
    patient_id integer NOT NULL,
    diagnosis_id integer NOT NULL
);
 )   DROP TABLE public.patient_and_diagnosis;
       public         heap    postgres    false            �            1259    24779    schedule    TABLE        CREATE TABLE public.schedule (
    id integer NOT NULL,
    start_time time without time zone NOT NULL,
    end_time time without time zone NOT NULL,
    action character varying NOT NULL,
    doctor_id integer NOT NULL,
    patient_id integer NOT NULL
);
    DROP TABLE public.schedule;
       public         heap    postgres    false            �            1259    24778    schedule_id_seq    SEQUENCE     �   ALTER TABLE public.schedule ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.schedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    231            �            1259    24621    shiz_i_diagnoz_id_seq    SEQUENCE     �   ALTER TABLE public.patient_and_diagnosis ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.shiz_i_diagnoz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    222            �            1259    24601    shizik_id_seq    SEQUENCE     �   ALTER TABLE public.patient ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.shizik_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    24615    vrach_i_shiz_id_seq    SEQUENCE     �   ALTER TABLE public.doctor_and_patient ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.vrach_i_shiz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    221            �            1259    24607    vrach_id_seq    SEQUENCE     �   ALTER TABLE public.doctor ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.vrach_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    216            �          0    24592    account 
   TABLE DATA           >   COPY public.account (id, login, password, status) FROM stdin;
    public          postgres    false    220   D       �          0    24583    chamber 
   TABLE DATA           ;   COPY public.chamber (id, capacity, type, area) FROM stdin;
    public          postgres    false    217   3D       �          0    24586 	   diagnosis 
   TABLE DATA           O   COPY public.diagnosis (id, severeness, description, drug_id, name) FROM stdin;
    public          postgres    false    218   PD       �          0    24580    doctor 
   TABLE DATA           ~   COPY public.doctor (id, name, surname, third_name, specialization, account_id, cabinet_number, phone_number, age) FROM stdin;
    public          postgres    false    216   mD       �          0    24595    doctor_and_patient 
   TABLE DATA           G   COPY public.doctor_and_patient (id, doctor_id, patient_id) FROM stdin;
    public          postgres    false    221   �D       �          0    24589    drug 
   TABLE DATA           ?   COPY public.drug (id, name, dose_type, type, dose) FROM stdin;
    public          postgres    false    219   �D       �          0    24577    patient 
   TABLE DATA           e   COPY public.patient (id, name, surname, third_name, chamber_id, rating, account_id, age) FROM stdin;
    public          postgres    false    215   �D       �          0    24598    patient_and_diagnosis 
   TABLE DATA           M   COPY public.patient_and_diagnosis (id, patient_id, diagnosis_id) FROM stdin;
    public          postgres    false    222   �D       �          0    24779    schedule 
   TABLE DATA           [   COPY public.schedule (id, start_time, end_time, action, doctor_id, patient_id) FROM stdin;
    public          postgres    false    231   �D                  0    0    account_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.account_id_seq', 1, false);
          public          postgres    false    229                       0    0    diagnoz_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.diagnoz_id_seq', 1, false);
          public          postgres    false    228                       0    0    palata_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.palata_id_seq', 1, false);
          public          postgres    false    227                       0    0    schedule_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.schedule_id_seq', 1, false);
          public          postgres    false    230                       0    0    shiz_i_diagnoz_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.shiz_i_diagnoz_id_seq', 1, false);
          public          postgres    false    226                       0    0    shizik_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.shizik_id_seq', 1, false);
          public          postgres    false    223            	           0    0    vrach_i_shiz_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.vrach_i_shiz_id_seq', 1, false);
          public          postgres    false    225            
           0    0    vrach_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.vrach_id_seq', 1, false);
          public          postgres    false    224            L           2606    24646    account account_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.account
    ADD CONSTRAINT account_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.account DROP CONSTRAINT account_pkey;
       public            postgres    false    220            F           2606    24632    chamber chamber_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.chamber
    ADD CONSTRAINT chamber_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.chamber DROP CONSTRAINT chamber_pkey;
       public            postgres    false    217            H           2606    24640    diagnosis diagnosis_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.diagnosis
    ADD CONSTRAINT diagnosis_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.diagnosis DROP CONSTRAINT diagnosis_pkey;
       public            postgres    false    218            N           2606    24620 *   doctor_and_patient doctor_and_patient_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT doctor_and_patient_pkey PRIMARY KEY (id);
 T   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT doctor_and_patient_pkey;
       public            postgres    false    221            D           2606    24612    doctor doctor_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.doctor
    ADD CONSTRAINT doctor_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.doctor DROP CONSTRAINT doctor_pkey;
       public            postgres    false    216            J           2606    24634    drug drug_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.drug
    ADD CONSTRAINT drug_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.drug DROP CONSTRAINT drug_pkey;
       public            postgres    false    219            P           2606    24626 0   patient_and_diagnosis patient_and_diagnosis_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT patient_and_diagnosis_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT patient_and_diagnosis_pkey;
       public            postgres    false    222            B           2606    24606    patient patient_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT patient_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.patient DROP CONSTRAINT patient_pkey;
       public            postgres    false    215            R           2606    24785    schedule schedule_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.schedule DROP CONSTRAINT schedule_pkey;
       public            postgres    false    231            S           2606    24667    patient account_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT account_fkey FOREIGN KEY (account_id) REFERENCES public.account(id) NOT VALID;
 >   ALTER TABLE ONLY public.patient DROP CONSTRAINT account_fkey;
       public          postgres    false    215    4684    220            U           2606    24773    doctor account_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor
    ADD CONSTRAINT account_id_fkey FOREIGN KEY (account_id) REFERENCES public.account(id) NOT VALID;
 @   ALTER TABLE ONLY public.doctor DROP CONSTRAINT account_id_fkey;
       public          postgres    false    220    4684    216            T           2606    24768    patient chamber_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT chamber_id_fkey FOREIGN KEY (chamber_id) REFERENCES public.chamber(id) NOT VALID;
 A   ALTER TABLE ONLY public.patient DROP CONSTRAINT chamber_id_fkey;
       public          postgres    false    4678    215    217            V           2606    24647    diagnosis diagnosis_drug_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.diagnosis
    ADD CONSTRAINT diagnosis_drug_fkey FOREIGN KEY (drug_id) REFERENCES public.drug(id) NOT VALID;
 G   ALTER TABLE ONLY public.diagnosis DROP CONSTRAINT diagnosis_drug_fkey;
       public          postgres    false    218    4682    219            Y           2606    24657 $   patient_and_diagnosis diagnosis_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT diagnosis_fkey FOREIGN KEY (diagnosis_id) REFERENCES public.diagnosis(id) NOT VALID;
 N   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT diagnosis_fkey;
       public          postgres    false    4680    218    222            W           2606    24672    doctor_and_patient doctor_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT doctor_fkey FOREIGN KEY (doctor_id) REFERENCES public.doctor(id) NOT VALID;
 H   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT doctor_fkey;
       public          postgres    false    221    4676    216            [           2606    24786    schedule doctor_id_fkey    FK CONSTRAINT     y   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT doctor_id_fkey FOREIGN KEY (doctor_id) REFERENCES public.doctor(id);
 A   ALTER TABLE ONLY public.schedule DROP CONSTRAINT doctor_id_fkey;
       public          postgres    false    216    231    4676            Z           2606    24652 "   patient_and_diagnosis patient_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT patient_fkey FOREIGN KEY (patient_id) REFERENCES public.patient(id) NOT VALID;
 L   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT patient_fkey;
       public          postgres    false    4674    222    215            X           2606    24677    doctor_and_patient patient_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT patient_fkey FOREIGN KEY (patient_id) REFERENCES public.patient(id) NOT VALID;
 I   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT patient_fkey;
       public          postgres    false    221    4674    215            \           2606    24791    schedule patient_id_fkey    FK CONSTRAINT     |   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT patient_id_fkey FOREIGN KEY (patient_id) REFERENCES public.patient(id);
 B   ALTER TABLE ONLY public.schedule DROP CONSTRAINT patient_id_fkey;
       public          postgres    false    231    215    4674            �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �     