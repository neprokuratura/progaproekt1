PGDMP      9                |            Durka    16.3    16.3 9    5           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            6           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            7           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            8           1262    49600    Durka    DATABASE     {   CREATE DATABASE "Durka" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Durka";
                postgres    false            �            1259    49601    account    TABLE     �   CREATE TABLE public.account (
    id integer NOT NULL,
    login character varying(20) NOT NULL,
    password character varying(20) NOT NULL,
    status boolean NOT NULL
);
    DROP TABLE public.account;
       public         heap    postgres    false            �            1259    49604    account_id_seq    SEQUENCE     �   ALTER TABLE public.account ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.account_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    49605    chamber    TABLE     �   CREATE TABLE public.chamber (
    id integer NOT NULL,
    capacity integer NOT NULL,
    type character varying(30) NOT NULL,
    area integer NOT NULL
);
    DROP TABLE public.chamber;
       public         heap    postgres    false            �            1259    49608 	   diagnosis    TABLE     �   CREATE TABLE public.diagnosis (
    id integer NOT NULL,
    severeness character varying(20) NOT NULL,
    description character varying(100),
    drugid integer,
    name character varying(30) NOT NULL
);
    DROP TABLE public.diagnosis;
       public         heap    postgres    false            �            1259    49611    diagnoz_id_seq    SEQUENCE     �   ALTER TABLE public.diagnosis ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.diagnoz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218            �            1259    49612    doctor    TABLE     U  CREATE TABLE public.doctor (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    thirdname character varying(20),
    specialization character varying(50) NOT NULL,
    accountid integer NOT NULL,
    cabinetnumber integer NOT NULL,
    phonenumber character varying NOT NULL
);
    DROP TABLE public.doctor;
       public         heap    postgres    false            �            1259    49615    doctor_and_patient    TABLE     �   CREATE TABLE public.doctor_and_patient (
    id integer NOT NULL,
    doctorid integer NOT NULL,
    patientid integer NOT NULL
);
 &   DROP TABLE public.doctor_and_patient;
       public         heap    postgres    false            �            1259    49618    drug    TABLE     �   CREATE TABLE public.drug (
    id integer NOT NULL,
    name character varying(30) NOT NULL,
    dosetype character varying(10) NOT NULL,
    type character varying(20) NOT NULL,
    dose integer NOT NULL
);
    DROP TABLE public.drug;
       public         heap    postgres    false            �            1259    49621    palata_id_seq    SEQUENCE     �   ALTER TABLE public.chamber ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.palata_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    49622    patient    TABLE       CREATE TABLE public.patient (
    id integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    thirdname character varying(20),
    chamberid integer NOT NULL,
    rating integer NOT NULL,
    accountid integer NOT NULL
);
    DROP TABLE public.patient;
       public         heap    postgres    false            �            1259    49625    patient_and_diagnosis    TABLE     �   CREATE TABLE public.patient_and_diagnosis (
    id integer NOT NULL,
    patientid integer NOT NULL,
    diagnosisid integer NOT NULL
);
 )   DROP TABLE public.patient_and_diagnosis;
       public         heap    postgres    false            �            1259    49628    schedule    TABLE     �   CREATE TABLE public.schedule (
    id integer NOT NULL,
    starttime time without time zone NOT NULL,
    endtime time without time zone NOT NULL,
    action character varying NOT NULL,
    doctorid integer NOT NULL,
    patientid integer NOT NULL
);
    DROP TABLE public.schedule;
       public         heap    postgres    false            �            1259    49633    schedule_id_seq    SEQUENCE     �   ALTER TABLE public.schedule ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.schedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    226            �            1259    49634    shiz_i_diagnoz_id_seq    SEQUENCE     �   ALTER TABLE public.patient_and_diagnosis ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.shiz_i_diagnoz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    225            �            1259    49635    shizik_id_seq    SEQUENCE     �   ALTER TABLE public.patient ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.shizik_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    224            �            1259    49636    vrach_i_shiz_id_seq    SEQUENCE     �   ALTER TABLE public.doctor_and_patient ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.vrach_i_shiz_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    221            �            1259    49637    vrach_id_seq    SEQUENCE     �   ALTER TABLE public.doctor ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.vrach_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            "          0    49601    account 
   TABLE DATA           >   COPY public.account (id, login, password, status) FROM stdin;
    public          postgres    false    215   �C       $          0    49605    chamber 
   TABLE DATA           ;   COPY public.chamber (id, capacity, type, area) FROM stdin;
    public          postgres    false    217   �C       %          0    49608 	   diagnosis 
   TABLE DATA           N   COPY public.diagnosis (id, severeness, description, drugid, name) FROM stdin;
    public          postgres    false    218   D       '          0    49612    doctor 
   TABLE DATA           u   COPY public.doctor (id, name, surname, thirdname, specialization, accountid, cabinetnumber, phonenumber) FROM stdin;
    public          postgres    false    220   9D       (          0    49615    doctor_and_patient 
   TABLE DATA           E   COPY public.doctor_and_patient (id, doctorid, patientid) FROM stdin;
    public          postgres    false    221   �D       )          0    49618    drug 
   TABLE DATA           >   COPY public.drug (id, name, dosetype, type, dose) FROM stdin;
    public          postgres    false    222   �D       +          0    49622    patient 
   TABLE DATA           ]   COPY public.patient (id, name, surname, thirdname, chamberid, rating, accountid) FROM stdin;
    public          postgres    false    224   �D       ,          0    49625    patient_and_diagnosis 
   TABLE DATA           K   COPY public.patient_and_diagnosis (id, patientid, diagnosisid) FROM stdin;
    public          postgres    false    225   1E       -          0    49628    schedule 
   TABLE DATA           W   COPY public.schedule (id, starttime, endtime, action, doctorid, patientid) FROM stdin;
    public          postgres    false    226   NE       9           0    0    account_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.account_id_seq', 2, true);
          public          postgres    false    216            :           0    0    diagnoz_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.diagnoz_id_seq', 1, false);
          public          postgres    false    219            ;           0    0    palata_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.palata_id_seq', 1, true);
          public          postgres    false    223            <           0    0    schedule_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.schedule_id_seq', 2, true);
          public          postgres    false    227            =           0    0    shiz_i_diagnoz_id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.shiz_i_diagnoz_id_seq', 1, false);
          public          postgres    false    228            >           0    0    shizik_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.shizik_id_seq', 1, true);
          public          postgres    false    229            ?           0    0    vrach_i_shiz_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.vrach_i_shiz_id_seq', 1, false);
          public          postgres    false    230            @           0    0    vrach_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.vrach_id_seq', 1, true);
          public          postgres    false    231            x           2606    49639    account account_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.account
    ADD CONSTRAINT account_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.account DROP CONSTRAINT account_pkey;
       public            postgres    false    215            z           2606    49641    chamber chamber_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.chamber
    ADD CONSTRAINT chamber_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.chamber DROP CONSTRAINT chamber_pkey;
       public            postgres    false    217            |           2606    49643    diagnosis diagnosis_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.diagnosis
    ADD CONSTRAINT diagnosis_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.diagnosis DROP CONSTRAINT diagnosis_pkey;
       public            postgres    false    218            �           2606    49645 *   doctor_and_patient doctor_and_patient_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT doctor_and_patient_pkey PRIMARY KEY (id);
 T   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT doctor_and_patient_pkey;
       public            postgres    false    221            ~           2606    49647    doctor doctor_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.doctor
    ADD CONSTRAINT doctor_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.doctor DROP CONSTRAINT doctor_pkey;
       public            postgres    false    220            �           2606    49649    drug drug_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.drug
    ADD CONSTRAINT drug_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.drug DROP CONSTRAINT drug_pkey;
       public            postgres    false    222            �           2606    49651 0   patient_and_diagnosis patient_and_diagnosis_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT patient_and_diagnosis_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT patient_and_diagnosis_pkey;
       public            postgres    false    225            �           2606    49653    patient patient_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT patient_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.patient DROP CONSTRAINT patient_pkey;
       public            postgres    false    224            �           2606    49655    schedule schedule_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.schedule DROP CONSTRAINT schedule_pkey;
       public            postgres    false    226            �           2606    49656    patient account_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT account_fkey FOREIGN KEY (accountid) REFERENCES public.account(id) NOT VALID;
 >   ALTER TABLE ONLY public.patient DROP CONSTRAINT account_fkey;
       public          postgres    false    224    215    4728            �           2606    49661    doctor account_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor
    ADD CONSTRAINT account_id_fkey FOREIGN KEY (accountid) REFERENCES public.account(id) NOT VALID;
 @   ALTER TABLE ONLY public.doctor DROP CONSTRAINT account_id_fkey;
       public          postgres    false    215    220    4728            �           2606    49666    patient chamber_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient
    ADD CONSTRAINT chamber_id_fkey FOREIGN KEY (chamberid) REFERENCES public.chamber(id) NOT VALID;
 A   ALTER TABLE ONLY public.patient DROP CONSTRAINT chamber_id_fkey;
       public          postgres    false    224    217    4730            �           2606    49671    diagnosis diagnosis_drug_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.diagnosis
    ADD CONSTRAINT diagnosis_drug_fkey FOREIGN KEY (drugid) REFERENCES public.drug(id) NOT VALID;
 G   ALTER TABLE ONLY public.diagnosis DROP CONSTRAINT diagnosis_drug_fkey;
       public          postgres    false    222    4738    218            �           2606    49676 $   patient_and_diagnosis diagnosis_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT diagnosis_fkey FOREIGN KEY (diagnosisid) REFERENCES public.diagnosis(id) NOT VALID;
 N   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT diagnosis_fkey;
       public          postgres    false    218    4732    225            �           2606    49681    doctor_and_patient doctor_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT doctor_fkey FOREIGN KEY (doctorid) REFERENCES public.doctor(id) NOT VALID;
 H   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT doctor_fkey;
       public          postgres    false    4734    220    221            �           2606    49686    schedule doctor_id_fkey    FK CONSTRAINT     x   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT doctor_id_fkey FOREIGN KEY (doctorid) REFERENCES public.doctor(id);
 A   ALTER TABLE ONLY public.schedule DROP CONSTRAINT doctor_id_fkey;
       public          postgres    false    226    220    4734            �           2606    49691 "   patient_and_diagnosis patient_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.patient_and_diagnosis
    ADD CONSTRAINT patient_fkey FOREIGN KEY (patientid) REFERENCES public.patient(id) NOT VALID;
 L   ALTER TABLE ONLY public.patient_and_diagnosis DROP CONSTRAINT patient_fkey;
       public          postgres    false    224    225    4740            �           2606    49696    doctor_and_patient patient_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.doctor_and_patient
    ADD CONSTRAINT patient_fkey FOREIGN KEY (patientid) REFERENCES public.patient(id) NOT VALID;
 I   ALTER TABLE ONLY public.doctor_and_patient DROP CONSTRAINT patient_fkey;
       public          postgres    false    224    221    4740            �           2606    49701    schedule patient_id_fkey    FK CONSTRAINT     {   ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT patient_id_fkey FOREIGN KEY (patientid) REFERENCES public.patient(id);
 B   ALTER TABLE ONLY public.schedule DROP CONSTRAINT patient_id_fkey;
       public          postgres    false    226    224    4740            "   &   x�3�442�4.#NmsSSSc D�p��qqq �.      $   %   x�3�4估�b�ņ.v\�$�9���b���� �'!      %      x������ � �      '   \   x���	�0�����a�(����E*��ry$_�<���Ņ����	��QM�v�DՉP�Pt6���:�#/�b	!xw3��3+      (      x������ � �      )      x������ � �      +   B   x�3估���[.6_�}a߅M�f\�|a�ņ�=��\�q��;!r@^;�!�)�!W� ��"      ,      x������ � �      -   :   x�3�44�2 !NC#(����=�^أpaх6^�}a�Ŧ�.��4�4����� =��     