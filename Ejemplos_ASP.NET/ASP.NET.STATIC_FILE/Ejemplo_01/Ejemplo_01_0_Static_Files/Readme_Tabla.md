## Breakpoints en Bootstrap

Bootstrap utiliza un sistema de grid basado en breakpoints para hacer el diseño responsive. 

Tamaños disponibles

| Tamaño  | Prefijo | Ancho mínimo | Ancho máximo |
|---------|--------|--------------|--------------|
| **Extra pequeño** | `col-`  | default | default |
| **Pequeño (Small)** | `col-sm-` | >=576px | <768px |
| **Mediano (Medium)** | `col-md-` | >=768px | <992px  |
| **Grande (Large)** | `col-lg-` | >=992px | <1199px |
| **Extra grande (XLarge)** | `col-xl-` | >=1200px | <* |

### Ejemplo de uso:
```html
<div class="col-12 col-sm-8 col-md-6 col-lg-4 col-xl-3">
    Contenido responsivo
</div>
```