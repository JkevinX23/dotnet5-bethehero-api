import React, { useState , useEffect } from 'react';
import {Link, useHistory} from 'react-router-dom';
import logoImg from '../../assets/logo.svg';
import {FiPower, FiTrash2} from 'react-icons/fi';
import './styles.css';
import api from '../../services/api';

export default function Profile(){
  const [incidents, setIncidents] = useState([]);

  const ongId = localStorage.getItem('ongId');
  const ongName = localStorage.getItem('ongName');
  const history = useHistory();

  useEffect( () => {
    api.get(`profile/${ongId}`, {
      headers: {
        authorization: ongId
      }
    }).then(response => {
      console.log(response.data)
      setIncidents(response.data);
  })
  },[ongId]);

  async function handlerDeleteIncident(id){
    try {
      await api.delete(`incidents/${id}`,{
        headers :{ 
          Authorization: ongId,
        }
      });

      setIncidents(incidents.filter(incident => incident.id !== id ))
    } catch (error) {
      alert('Erro ao deletar caso, tente novamente');
    }
  }

  function handleLogout(){
    localStorage.clear();

    history.push('/');
  }

  return(
    <div className="profile-container">
      <header>
        <img src={logoImg} alt="Be The Hero"/>
  <span>Bem vinda, {ongName}</span>
        
        <Link className="button" to="/incidents/new">Cadastrar novo caso</Link>
        <button onClick={handleLogout} type="button">
          <FiPower size={18} color="#e02048" />
        </button>
       </header>   
      <h1>Casos cadastrados</h1>
        <ul>
         {
           incidents.map(incident =>  (
            <li key={incident.id}>
              <strong>CASO:</strong>
              <p>{incident.titulo}</p>

              <strong>DESCRIÇÃO:</strong>
              <p>{incident.descricao}</p>

              <strong>VALOR: </strong>
              <p>{Intl.NumberFormat('pt-BR',{style: 'currency', currency:'BRL'}).format(incident.valor)}</p>
              
              <button onClick={()=> handlerDeleteIncident(incident.id)} type="button">
                <FiTrash2 size={20} color="#a8a8b3"/>
              </button>
          </li>
           ))
         }
        </ul>
    </div>
  );
}