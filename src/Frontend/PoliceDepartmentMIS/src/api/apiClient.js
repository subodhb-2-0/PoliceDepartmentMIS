// Utility function to retrieve token from sessionStorage

  // const { VITE_WEB_API } = import.meta.env
const getAuthToken = () => {
    const user = localStorage.getItem('user')||{};
    const token = JSON.parse(user);
    return token;
}
  // Centralized error handling
  const handleErrorResponse = async (response) => {
    if (response.status === 204) {
      return null;
    }
    if (!response.ok) {
      if (response.status === 401) {
        unauthenticateUser();
        return;
      }
      if (response.status === 400) {
        const resp = await response.json();
        console.error('Error:', resp.message || 'Something went wrong');
        alert(`Error: ${resp?.message || 'Something went wrong'}`);
        return;
      }
      alert("Failed to Process your request");
      return;
    }
    return response.json();
  }
  
  // Function to unauthenticate the user
  const unauthenticateUser = () => {
    sessionStorage.removeItem('user');
  }
  
  // Generic HTTP POST function with JSON body
  export const httpPost = async (url, data) => {
    const token = getAuthToken();
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
      body: JSON.stringify(data)
    });
    return handleErrorResponse(response);
  }
  
  // HTTP POST function with FormData
  export const httpPostForm = async (url, data) => {
    const token = getAuthToken();
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Authorization': 'Bearer ' + token
      },
      body: data
    });
    return handleErrorResponse(response);
  }
  
  // Generic HTTP GET function
  export const httpGet = async (url) => {
    const token = getAuthToken();
    const response = await fetch(url, {
      method: 'GET',
      headers: {
        'Authorization': 'Bearer ' + token
      }
    });
    return handleErrorResponse(response);
  }
  
  // Generic HTTP PUT function
  export const httpPut = async (url, data) => {
    const token = getAuthToken();
    const response = await fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
      body: JSON.stringify(data)
    });
    return handleErrorResponse(response);
  }
  
  // Generic HTTP DELETE function
  export const httpDelete = async (url) => {
    const token = getAuthToken();
    const response = await fetch(url, {
      method: 'DELETE',
      headers: {
        'Authorization': 'Bearer ' + token
      }
    });
    return handleErrorResponse(response);
  }
  