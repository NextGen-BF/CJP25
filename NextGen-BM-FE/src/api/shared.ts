export const apiURL = import.meta.env.VITE_API_BASE_URL;

//Generic request to avoid duplication
export async function request<T>(url: string, options: RequestInit): Promise<T> {
    options.headers = {
      "Content-Type": "application/json",
      ...options.headers,
    };
    let response: Response;
  
    // eslint-disable-next-line no-useless-catch
    try {
      response = await fetch(url, options);
    } catch (error) {
      throw error;
    }
    if (response.headers.get("content-length") === "0") {
      return undefined as T;
    }
  
    const data = await response.json();
  
    if (response.ok) {
      return data;
    }
  
    return undefined as T;
  }