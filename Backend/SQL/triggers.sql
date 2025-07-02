

CREATE OR REPLACE FUNCTION actualizar_precio_total()
RETURNS TRIGGER AS $$
BEGIN
    -- Calcula el precio total con base en el precio unitario del repuesto
    SELECT r.precio_unitario INTO STRICT NEW.precio_total
    FROM repuestos r
    WHERE r.repuesto_id = NEW.repuesto_id;

    -- Multiplica por la cantidad
    NEW.precio_total := NEW.precio_total * NEW.cantidad;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;


CREATE TRIGGER trg_actualizar_precio_total
BEFORE INSERT OR UPDATE ON detalles_ordenes
FOR EACH ROW
EXECUTE FUNCTION actualizar_precio_total();

-- Tabla : facturas

CREATE OR REPLACE FUNCTION calcular_valores_factura()
RETURNS TRIGGER AS $$
BEGIN
    -- Calcular mano de obra (10% del monto total)
    NEW.mano_obra := ROUND(NEW.monto_total * 0.10, 2);

    -- Calcular valor total (monto total + mano de obra)
    NEW.valor_total := ROUND(NEW.monto_total + NEW.mano_obra, 2);

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_calcular_valores_factura
BEFORE INSERT OR UPDATE ON facturas
FOR EACH ROW
EXECUTE FUNCTION calcular_valores_factura();