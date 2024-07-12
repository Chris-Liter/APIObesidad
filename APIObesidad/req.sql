select * from "Usuario"


CREATE TABLE public.turnos (
    id serial PRIMARY KEY,
    fecha text NOT NULL,
    hora text NOT NULL,
    id_usuario integer NOT NULL,
    CONSTRAINT fk_usuario
        FOREIGN KEY(id_usuario) 
        REFERENCES "Usuario"(id)
);



ALTER TABLE turnos RENAME TO "Turnos";

select * from "Turnos"

delete from "Turnos" where id = 2