import React, {useEffect, useState} from 'react'
import {Link} from 'react-router-dom';
import MaterialTable from 'material-table';
import logoImg from '../../assets/logo.svg';
import { FiArrowLeft } from 'react-icons/fi';
import api from '../../services/api';

import "./styles.css"

export default function Dashboard(){
  const [ongs, setOngs] = useState([]);
  const [columns] = useState([
    { title: 'ID', field: 'id',  editable: 'never' },
    { title: 'Nome', field: 'name'},
    { title: 'Email', field: 'email' },
    { title: 'Whatsapp', field: 'whatsapp' },
    { title: 'Cidade', field: 'city'},
    { title: 'UF', field: 'uf'},
  ]);

  useEffect(() => {
    async function loadOngs(){
      const { data } = await api.get('dashboard');
      setOngs(data)
    }
    loadOngs();
  }, [])

  async function editOng(newOng){
    await api.put('dashboard', newOng);
    const { data } = await api.get('dashboard');
    setOngs(data)
  }

  async function deleteOng(ong){
    await api.delete(`dashboard/${ong.id}`)
    const { data } = await api.get('dashboard');
    setOngs(data)
  }

  async function newOng(ong){
    await api.post('ongs',ong);
    const { data } = await api.get('dashboard');
    setOngs(data)
  }

  return(
    <div className="new-incident-container">
      <div className="content">
        <section>
          <img src={logoImg} alt="Be The Hero"/>
          <h1>Dashboard</h1>
          <p>Sessão criada para o gerenciamento das ONGS.</p>


          <Link className="back-link" to="/profile">
              <FiArrowLeft size={16} color="#E02041"/>
                Voltar para home
          </Link>
        </section>

        <div className="table">
          <MaterialTable
            title="Ongs"
            columns={columns}
            data={ongs}
            options={{ exportButton: true }}
            localization={{
              header: { actions: 'Ações' },
              toolbar: {
                exportName: 'Exportar como CSV',
                exportAriaLabel: 'Exportar como CSV',
                searchPlaceholder: 'Buscar',
                searchTooltip: 'Buscar na tabela',
              },
              pagination: {
                labelRowsSelect: 'Registros por página',
              },
              body: {
                editRow: {
                  deleteText: "Deseja mesmo apagar essa ong?"
                }
              }
            }}
            editable={{
              onRowUpdate: (newData, oldData) => editOng(newData, oldData),
              onRowDelete: (data) => deleteOng(data),
              onRowAdd: (data) => newOng(data),
            }}
          />
        </div>
      
      </div>
    </div>
  );
}