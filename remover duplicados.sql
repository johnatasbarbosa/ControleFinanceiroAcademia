select * from Alunos where Ativo = 1

select * from Ciclos where Aluno_Id = 181

select * from Meses order by Data, Ciclo_Id

select * from Meses where Ciclo_Id = 185

WITH cte AS (
    SELECT
        Id,
        Data,
        Pago,
        DiaPagamento,
		Ciclo_Id,
        ROW_NUMBER() OVER (
            PARTITION BY
                Data,
				Pago,
				DiaPagamento,
				Ciclo_Id
            ORDER BY
                Data,
				Pago,
				DiaPagamento,
				Ciclo_Id
        ) row_num
     FROM
        Meses
)
select * FROM cte
WHERE row_num > 1;

DELETE FROM cte
WHERE row_num > 1;