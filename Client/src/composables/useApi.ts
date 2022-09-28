import { FetchOptions } from 'ohmyfetch';

export const useApi = async (url: string, options?: FetchOptions): Promise<any> => {
  let token = null;
  let tempOpts = {}; 

  const {
    public: { baseURL },
  } = useRuntimeConfig();

  if (process?.client) {
    token = window.localStorage.getItem('token');
  }

  let headers = {};
  if (token) {
    headers = {
      Authorization: `Bearer ${token}`,
      'content-type': 'application/json',
    };
  }

  tempOpts = { ...options, headers: { ...headers } };

  const apiUrl = url?.includes(baseURL) ? url : `${baseURL}${url}`;
  return await $fetch(apiUrl, tempOpts);
};
